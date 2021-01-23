    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Text;
    
    namespace ConsoleApplication
    {
    	class Program
    	{
    		private static void SequencesInner(byte[] bytes, int i, Action<byte[]> action)
    		{
    			if (i == bytes.Length)
    			{
    				action(bytes);
    			}
    			else
    			{
    				int j = i + 1;
    				for (int v = 0; v < 256; v++)
    				{
    					bytes[i] = Convert.ToByte(v);
    					SequencesInner(bytes, j, action);
    				}
    			}
    		}
    
    		private static void Sequences(int length, Action<byte[]> action)
    		{
    			for (int n = 1; n <= length; n++)
    			{
    				SequencesInner(new byte[n], 0, action);
    			}
    		}
    
    		static void Main()
    		{
    			var maxBufferSize = 2;
    			var outputFilePath = Path.GetTempFileName();
    			var sb = new StringBuilder();
    			using (var sw = new StreamWriter(outputFilePath))
    			{
    				Sequences(
    					maxBufferSize,
    					a => sw.WriteLine(sb.Clear().Append("0x").Append(String.Join("", Array.ConvertAll(a, x => x.ToString("X2", CultureInfo.InvariantCulture))))));
    				sw.Flush();
    			}
    			var process = Process.Start("notepad.exe", outputFilePath);
    			process.WaitForExit();
    			File.Delete(outputFilePath);
    		}
    	}
    }

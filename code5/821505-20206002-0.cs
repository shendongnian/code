            string Path = (@"C:\Users\x\Documents\Visual Studio 2012\Projects\MTest\txtCmdLog.txt");
            using(StreamWriter sw = new StreamWriter(File.Open(Path, System.IO.FileMode.Append)))
            {
                for (int i = 0; i < txtCmdLog.Lines.Length; i++)
                {
                     sw.WriteLine(txtCmdLog.Lines[i] + "\n");
    
                }
    
            }

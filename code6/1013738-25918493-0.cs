    using System;
    using System.Speech.Recognition;
    
    namespace SR
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			using (var sre = new SpeechRecognitionEngine())
    			{
    				sre.SetInputToWaveFile(@"D:\test.wav");
    				sre.LoadGrammar(new DictationGrammar());
    
    				sre.BabbleTimeout = new TimeSpan(Int32.MaxValue);
    				sre.InitialSilenceTimeout = new TimeSpan(Int32.MaxValue);
    				sre.EndSilenceTimeout = new TimeSpan(100000000);
    				sre.EndSilenceTimeoutAmbiguous = new TimeSpan(100000000);
    
    				var result = sre.Recognize();
    				Console.WriteLine(result.Text);
    			}
    			
    			Console.ReadLine();
    
    		}
    	}
    }

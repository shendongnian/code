    using System;
    using System.ComponentModel;
    using System.Threading;
    using System.Windows.Forms;
    
    namespace Test
    {
    	class MainClass
    	{
    		public static void Main (string[] args)
    		{
    			Thread.GetDomain ().ProcessExit += (object sender, EventArgs e) => {
    				Console.WriteLine ("Foo!");
    			};
    			BackgroundWorker autokill = new BackgroundWorker ();
    			autokill.DoWork += (object sender, DoWorkEventArgs e) => {
    				Thread.Sleep (5000);
    				Environment.Exit (0);
    			};
    			autokill.RunWorkerAsync ();
    			Application.Run ();
    		}
    	}
    }

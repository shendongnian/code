    public partial class MainWindow : Window
    	{
    		delegate void TestDelegate();
    		public MainWindow()
    		{
    			InitializeComponent();
    
    			System.Threading.Thread.CurrentThread.Name = "UI THREAD";
    			System.Timers.Timer t = new System.Timers.Timer(500);
    			System.Threading.Thread td = new System.Threading.Thread(
    				(obj) => 
    				{ 
    					Console.WriteLine("Thread");
    					t.Elapsed += new System.Timers.ElapsedEventHandler(t_Elapsed);
    					t.Start();
    					while (true)
    					{
    						System.Threading.Thread.Sleep(1000);
    						Console.WriteLine("From Lambda: Current Thread Name: " + System.Threading.Thread.CurrentThread.Name);
    					}
    				}
    				);
    			td.Name = "K's Thread";
    			td.Start(null);
    		}
    
    		void DoInUIThread()
    		{
    			Console.WriteLine("DoInUIThread: Current Thread Name: " + System.Threading.Thread.CurrentThread.Name);
    		}
    
    		void t_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    		{
    			Console.WriteLine("t_Elapsed: Current Thread Name: " + System.Threading.Thread.CurrentThread.Name);
    			TestDelegate td = new TestDelegate(DoInUIThread);
    			Application.Current.Dispatcher.BeginInvoke(td );
    		}
    	}

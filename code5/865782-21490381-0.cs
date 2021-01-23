    namespace TstTxtBoxUpdate
    {
    	static class Program
    	{
    		/// <summary>
    		/// The main entry point for the application.
    		/// </summary>
    		[STAThread]
    		static void Main()
    		{
    			Aag_PrepDisplay aag_Prep1 = new Aag_PrepDisplay();
    
    			Thread AagPrepDisplayThread = new Thread(new ThreadStart(aag_Prep1.PrepareDisplay));
    			AagPrepDisplayThread.Start();
    
    			while(!AagPrepDisplayThread.IsAlive)
    				;
    			Thread.Sleep(1000);
    
    			Application.EnableVisualStyles();
    			Application.SetCompatibleTextRenderingDefault(false);
    			Application.Run(new SetOperation());
    		}
    	}
    }
    
    namespace TstTxtBoxUpdate
    {
    	// Thread 1: UI
    	public partial class SetOperation : Form
    	{
    		private string text;
    		public event Action<object> OnChDet;
    		
    		delegate void SetTextCallback(string text);
    		private Thread demoThread = null;
    		
    		public SetOperation()
    		{
    			InitializeComponent();
    			OnChDet += chDetDisplayHandler;
    		}
    		
    		public void FireEvent(Aag_PrepDisplay aagPrep)
    		{
    			OnChDet(mName);
    		}
    
    		private void chDetDisplayHandler(object name)
    		{
    			this.demoThread = new Thread(new ThreadStart(this.ThreadProcSafe));
    			this.demoThread.Start();
    		}
    
    		private void ThreadProcSafe()
    		{
    			this.SetText("402.5");
    		}
    		
    		private void SetText(string text)
    		{
    			if(this.actFreqChan1.InvokeRequired)
    			{
    				SetTextCallback d = new SetTextCallback(SetText);
    				this.Invoke(d, new object[] { text });
    			}
    			else
    			{
    				// TextBox NOT updated when event called from FireEvent() that was called from Thread 2 PrepareDisplay()
    				// TextBox IS updated when event called from Thread 1: SetOperation() or FireEvent()
    				this.actFreqChan1.Text = text;
    			}
    		}
    	}
    }
    
    namespace TstTxtBoxUpdate
    {
    	// Thread 2: Data prepare
    	public class Aag_PrepDisplay
    	{
    		#region Fields
    
    		private Aag_PrepDisplay mAagPrep;
    
    		#endregion Fields
    
    		#region Properties
    
    		public Aag_PrepDisplay AagPrepDisp;
    
    		public Aag_PrepDisplay AagPrep
    		{
    			get { return mAagPrep; }
    			set { mAagPrep = value; }
    		}
    
    		#endregion Properties
    
    		#region Methods
    
    		public void PrepareDisplay()
    		{
    			mAagPrep = new Aag_PrepDisplay();
    			SetOperation setOp1 = new SetOperation();
    			setOp1.FireEvent(mAagPrep);		// calls Thread 1 method that will fire the event
    		}
    
    		#endregion Methods
    	}
    }  

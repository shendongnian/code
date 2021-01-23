	public partial class Form1 : Form
	{
		MyTestCallBack _callback;
		
		public Form1()
		{
			InitializeComponent();
			_callback = new MyTestCallBack();
			_callback.MyTestCallBackEvent += callback_MyTestCallBackEvent;
			_callback.OnUpdate();
		}
		private callback_MyTestCallBackEvent(MyTestCallBackEventArgs e)
		{
			// TODO: Invoke code here with e.g. label1.Text = e.SomeObj.ToString()...
		}
	}
	class MyTestCallBackEventArgs : EventArgs
	{
		public SomeObject SomeObj { get; set; }
	}
	class MyTestCallBack : Callback
	{
		public event EventHandler<MyTestCallBackEventArgs> MyTestCallBackEvent;
		private SomeObject _so;
		public MyTestCallBack()
		{
			//
		}
		
		protected virtual void OnMyTestCallBackEvent(MyTestCallBackEventArgs e)
		{
			if (MyTestCallBackEvent != null)
				MyTestCallBackEvent(e);
		}
		
		public void OnUpdate(SomeObject someobj)
		{
			_so = someobj;
			OnMyTestCallBackEvent(new MyTestCallBackEventArgs { SomeObject = _so });
		}
	}

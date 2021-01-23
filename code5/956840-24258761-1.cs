	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
			var timer = new myCount (1000, 100, this); // Inject reference to owning Activity.
			timer.Start ();
		}
		public class myCount : CountDownTimer
		{
			Activity m_owner;
			public myCount(long millisInFuture, 
				long countdownIntervall, Activity owner) : base(millisInFuture,countdownIntervall)
			{
				m_owner = owner;
			}
			public override void OnFinish ()
			{
				Console.WriteLine ("Done");
			}
			public override void OnTick (long millisUntilFinished)
			{
				var countdownText = m_owner.FindViewById<TextView> (Resource.Id.countdownTimerText); // Invoke on parent instance.
				countdownText.Text = ("" + millisUntilFinished);
				Console.WriteLine ("test" + millisUntilFinished / 1000);
			}
		}  
	}

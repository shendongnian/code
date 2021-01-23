    [Activity (Label = "AsyncSample", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private CancellationTokenSource cancellation;
        private Button button;
        private Task task;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate (bundle);
            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            // Get our button from the layout resource,
            // and attach an event to it
            button = FindViewById<Button> (Resource.Id.myButton);
            button.Enabled = false;
            this.cancellation = new CancellationTokenSource ();
            this.task = RunTask(this.cancellation.Token, new Progress<int> (a => this.button.Text = string.Format ("Progress {0}", a)));
        }
        protected override void OnDestroy()
        {
            this.cancellation.Cancel ();
            base.OnDestroy ();
        }
    //        protected override void OnStop()
    //        {
    //            base.OnStop ();
    //            this.cancellation.Cancel ();
    //        }
    //
    //        protected override async void OnStart()
    //        {
    //            base.OnStart ();
    //
    //            this.cancellation = new CancellationTokenSource ();
    //            await RunTask (this.cancellation.Token, new Progress<int> (a => this.button.Text = string.Format ("Progress {0}", a)));
    //        }
        private Task RunTask(CancellationToken cancelToken, IProgress<int> progress)
        {
            return Task.Factory.StartNew(()=>
            {
                for (var n = 0; n < 100 && !cancelToken.IsCancellationRequested;)
                {
    //                    await Task.Delay (1000);
                    Thread.Sleep(1000);
                    progress.Report (++n);
                }
            });
        }
    }

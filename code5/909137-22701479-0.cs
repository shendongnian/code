        public async override void ViewDidLoad()
        {
            base.ViewDidLoad ();
            var d1 = Task.Delay (10);
            var d2 = Task.Delay (10000);
            //await Task.Delay (10);
            Task.WaitAll (d1, d2);
            this.label.Text = "Tasks have ended - really!";
        }
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear (animated);
            this.label.Text = "Tasks have ended - or have they?";
        }

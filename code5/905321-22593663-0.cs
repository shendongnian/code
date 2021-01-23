        private UIButton[] buttons;
        private Random random;
        public override void ViewDidLoad()
        {
            base.ViewDidLoad ();
			
            this.buttons = new [] { btnA, btnB, btnC, btnD };
            this.random = new Random ();
            // put in an event handler to fire up ButtonColor
        }
        private async void ButtonColor()
        {
            var r = random.Next (0, this.buttons.Length);
            if (r < this.buttons.Length)
            {
                var button = this.buttons [r];
                var curColor = button.TitleColor(UIControlState.Normal);
                button.SetTitleColor(UIColor.Magenta, UIControlState.Normal);
                await Task.Delay (2000);
                button.SetTitleColor(curColor, UIControlState.Normal);
            }
        }

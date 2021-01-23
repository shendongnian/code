    public class Popupex : Popup
        {
            public Popupex()
            {
                this.Opened += Popupex_Opened;
            }
    
            void Popupex_Opened(object sender, EventArgs e)
            {
                DispatcherTimer time = new DispatcherTimer();
                time.Interval = TimeSpan.FromSeconds(10);
                time.Start();
                time.Tick += delegate
                {
                    this.IsOpen = false;
                    time.Stop();
                };
            }
        }

    public class Alert
    {
        public string Message { get; set; }
        public string Header { get; set; }
        public Uri Image { get; set; } 
        public string ButtonCaption { get; set; }
        #if (DEBUG)
        public Alert()
        {
            this.Header = "Alert";
            this.ButtonCaption = "OK";
            this.Image = new Uri("http://stackoverflow.com/content/stackoverflow/img/apple-touch-icon.png");
            this.Message = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
        }
        #endif
        public Alert(string Header, string Message, string ButtonCaption, Uri Image)
        {
            this.Header = Header;
            this.Message = Message;
            this.ButtonCaption = ButtonCaption;
            this.Image = Image;
        }
        public Mvvm.Command ButtonClick
        {
            get
            {
                return new Mvvm.Command(() =>
                {
                    if (ButtonClicked != null)
                        ButtonClicked(this, new EventArgs());
                });
            }
        }
        public event EventHandler ButtonClicked;
    }

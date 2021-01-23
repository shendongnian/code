    class MainViewModel : Mvvm.ViewModel
    {
        private Alert _pageAlert = null;
        public Alert PageAlert { get { return this._pageAlert; } set { this._pageAlert = value; this.PropertyChange("PageAlert"); } }
        public Mvvm.Command ShowAlert
        {
            get
            {
                return new Mvvm.Command(() =>
                {
                    this.PageAlert = new Alert();
                    this.PageAlert.ButtonClicked += PageAlert_ButtonClicked;
                });
            }
        }
        void PageAlert_ButtonClicked(object sender, EventArgs e)
        {
            this.PageAlert = null;
        }
    }

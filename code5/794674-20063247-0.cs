    public class CustomSettingsFlyout : SettingsFlyout
    {
        bool back = false;
        private Popup popup;
        public void ShowWindow()
        {
            ShowIndependent();
            back = false;
            popup = (Parent as Popup);
            popup.IsLightDismissEnabled = false;
            popup.Closed += Popup_Closed;
            this.BackClick += CustomSettingsFlyout_BackClick;
        }
        void CustomSettingsFlyout_BackClick(object sender, BackClickEventArgs e)
        {
            back = true;
        }
        private void Popup_Closed(object sender, object e)
        {
            if (!back) popup.IsOpen = true;
        }
    }

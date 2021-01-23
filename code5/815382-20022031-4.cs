    public class PopupForm : Form
    {
        public string Caption { get; private set; }
        public PopupForm(string caption)
        {
            this.Caption = caption;
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            PopupManager.AddPopup(this);
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            PopupManager.RemovePopup(this);
        }
    }

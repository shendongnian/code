    public class MyButton : Button
    {
        private Label _Label = null;
        public Label Label
        {
            get { return _Label; }
            set { _Label = value; }
        }
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if (this.Label != null)
            {
                this.Label.Text = this.Name;
            }
        }
    }

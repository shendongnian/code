    class Button2 : Button
    {
        public string LabelName = "";
        public Button2()
        {
            this.Click += this.SetLabelName;
        }
        private void SetLabelName(object sender, EventArgs e)
        {
            this.LabelName = "Something?";
        }
    //You could also do this instead.
        protected override void OnClick(EventArgs e)
            {
                base.OnClick(e);
            }
        }

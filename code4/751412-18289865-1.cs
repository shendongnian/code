    class ButtonList : ContainerControl
    {
        // ...
        public ButtonListItemCollection Items { get; private set; }
        protected override void OnPaint(PaintEventArgs pe)
        {
            if (this.Site.DesignMode)
            {
                this.Items.RemoveAll(x => !this.Controls.Contains(x));
            }
        }
        // ...
    }

    public void MyTabControl : TabControl
    {
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if(e.Key != Key.Home)
            {
                base.OnKeyDown(e);
            }
        }
    }

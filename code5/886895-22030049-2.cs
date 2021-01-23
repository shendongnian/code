        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            base.OnBackKeyPress(e);
            
            if (web.Visibility = Visibility.Visibile)
            {
                web.Visibility = Visibility.Collapsed;
                e.Cancel = true;
            }
        }

        protected override void OnHardwareButtonsBackPressed(object sender, BackPressedEventArgs e)
        {
            var page = (Page)((Frame)Window.Current.Content).Content;
            if (page is INavigateBackwards)
            {
                var navigatingPage = (INavigateBackwards)page;
                if (!navigatingPage.CanNavigateBack())
                {
                    e.Handled = true;
                    return;
                }
            }
            base.OnHardwareButtonsBackPressed(sender, e);
        }

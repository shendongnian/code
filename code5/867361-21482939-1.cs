    dgGrid.ItemsSource = new List<object>() { new { I = 10, J = 20 }, new { I = 10, J = 20 }, new { I = 10, J = 20 }, new { I = 10, J = 20 }, new { I = 10, J = 20 } };
            Dispatcher.Invoke(new Action(delegate()
            {
                grd.SelectedIndex = 0;
                grd.Focus();
            }
        ), System.Windows.Threading.DispatcherPriority.Background);

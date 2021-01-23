    private void dataGrid1_LoadingRow(object sender, DataGridRowEventArgs e)
            {
                
                    if (Your condition)
                    {
                        e.Row.Background = new SolidColorBrush(Colors.Green);
                    }
                 
            }

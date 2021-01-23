    private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox chc = sender as CheckBox;
            try
            {
                foreach (var item in mEmployees)
                {
                    if (item.Dep.ToString() == chc.Content.ToString())
                    {
                        item.IsSelected = true;
                        MessageBox.Show(chc.Content.ToString());
                    }
                     
                }
            }
            catch
            {
            }
     }
           

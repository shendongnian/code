    if (NumberData.SelectedIndex == -1)
           {
               System.Windows.MessageBox.Show("nothing selected");
           }
           else
           {
               int indexSelected = Convert.ToInt32(NumberData.SelectedIndex);
               mycollection.Numbers.RemoveAt(indexSelected);
           }

    foreach (var selecteditem in ContactResultsData.SelectedItems)
                {
                    //MessageBox.Show(selecteditem.ToString());
                   
                    ContactResultsLabel.Text = selecteditem.Name;
                    ContactNumberResult.Text = selecteditem.Number;
    
                    listOfNames.Add(strItem);
    
                    //System.Diagnostics.Debug.WriteLine(strItem);
                    //MessageBox.Show("Saving " + strItem);
                }

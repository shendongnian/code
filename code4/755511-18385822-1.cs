    foreach (var selecteditem in ContactResultsData.SelectedItems)
                {
                    //MessageBox.Show(selecteditem.ToString());
                   
                    ContactResultsLabel.Text = selecteditem.Name;//The Name is ContactResultsData.SelectedItems return Column Field name
                    ContactNumberResult.Text = selecteditem.Number;//The Name is ContactResultsData.SelectedItems return Column Field name
    
                    listOfNames.Add(strItem);
    
                    //System.Diagnostics.Debug.WriteLine(strItem);
                    //MessageBox.Show("Saving " + strItem);
                }

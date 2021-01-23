    //Whole List
    settings.HeaderFields = checkedlstBoxHeaderField.Items.OfType<string>().ToArray();
    System.IO.File.WriteAllLines(@"C:\TestFolder\AllData.txt", HeaderFields );
    
    //Selected List
    settings.HeaderFields = checkedlstBoxHeaderField.CheckedItems.OfType<string>().ToArray();
    System.IO.File.WriteAllLines(@"C:\TestFolder\SelectedData.txt", HeaderFields );
    
    
    
    //Read Them back from files
    
    settings.HeaderFields  = System.IO.File.ReadAllLines(@"C:\TestFolder\AllData.txt");
    checkedlstBoxHeaderField.Items.AddRange(settings.HeaderFields);
    Controls.Add(checkedlstBoxHeaderField);
    
    settings.HeaderFields  = System.IO.File.ReadAllLines(@"C:\TestFolder\SelectedData.txt");
    //now loop through the Checkbox list add select the accoring to the data from SelectedData.txt
    
    
    System.IO.File.Delete(@"C:\TestFolder\SelectedData.txt");
    System.IO.File.Delete(@"C:\TestFolder\AllData.txt");

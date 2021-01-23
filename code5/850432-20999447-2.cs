    void cboLanden_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
       foreach(string fileName in e.AddedItems)
       {        
         string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
         foreach(string line in File.ReadLines(path))
            lstWinkels.Items.Add(line);
       }
       // handle RemovedItems
    }  

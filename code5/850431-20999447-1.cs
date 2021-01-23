    void cboLanden_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
       foreach(string fileName in e.AddedItems)
       {        
         string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
         string content = File.ReadAllText(path)
         lstWinkels.Items.Add(content);
       }
       // handle RemovedItems
    }  

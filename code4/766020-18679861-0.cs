    void _students_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        string name = string.Empty;
    
         if (e.NewItems != null && e.NewItems.Count > 0)
        {
            var student = e.NewItems[0] as Student;
            if (student != null) name = student.Name;
        }
    
        lstLog.Items.Add(string.Format("{0} Name:", name)); 
    }

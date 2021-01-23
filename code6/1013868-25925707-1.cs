    foreach (CheckBox cb in myBoxes)
    {      
        Datagrid dg = new Datagrid
          {
            Name = "NameGoesHere"; // Maybe you're wanting to use cb.Name or cb.Text?
            Location = "Location Here";
            IsChecked = cb.IsChecked;
          };
        db.DataGrids.Add(dg);
        db.SaveChanges(); 
    } 

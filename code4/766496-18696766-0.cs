    List<CheckBox> Sectionlist=new List<CheckBox>();
        for (int i = 0; i < objSections.RowCount; i++)
        {
    
            Sectionlist.Add(new CheckBox(){Text=objSections.Name,Location=new Point(0,i*20)});  
        }

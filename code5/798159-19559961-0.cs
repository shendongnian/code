    gridControl.DataSource = new List<DataObj> { 
        new DataObj(){ Agent = "AMD" },
        new DataObj(){ Agent = "!!!AMD" },
    };
    ((ColumnView)gridControl.MainView).ActiveFilterString = "[Agent] NOT LIKE '!!!%'";

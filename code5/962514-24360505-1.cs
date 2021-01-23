    public void ConvertListToDataTable()
    {
        DataTable dt = new DataTable();
        Node obj = new Node();
        //here obj is instance of your node type
        foreach (var item in obj.GetType().GetProperties())
        {
            dt.Columns.Add(item.Name);
        }
        List<Node> objDetails = new List<Node>();
        Node objNode = new Node();
        objNode.Name = true;
        objNode.Id = "Test B";
        Node objNode1 = new Node();
        objNode1.Name = false;
        objNode1.Id = "Test B 1";
        objDetails.Add(objNode);
        objDetails.Add(objNode1);
        
        DataRow dr;
        for (int i = 0; i < objDetails.Count; i++)
        {
            dr = dt.NewRow();
            foreach (var item in obj.GetType().GetProperties())
            {
                dr[item.Name] = objDetails[i].GetType().GetProperty(item.Name).GetValue(objDetails[i], null);
            }
            dt.Rows.Add(dr);
        }
        dt.AcceptChanges();
        data1.ItemsSource = dt.DefaultView;
    }

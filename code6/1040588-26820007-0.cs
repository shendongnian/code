     ParseQuery<ParseObject> query = ParseObject.GetQuery("binInformation");
        IEnumerable<ParseObject> res = await query.FindAsync();
        List<string> list = new List<string>();
            
        foreach (var i in res)
        {
            var s = i.Get<string>("binLocation");
            list.Add(s);
            
        }
        for (int intCounter = 0; intCounter < list.Count; intCounter++)
        {
            object obj = list[intCounter];
            
            cbSelectArea.Items.Add(obj);
        }

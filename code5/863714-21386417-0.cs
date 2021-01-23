    List<Data> data = new List<Data>();
    foreach (String line in ItemList)
    {
        string[] vars = line.Split(',');
        if (vars.Length == 6)
        {
            int id;
            if(!int.TryParse(vars[0], out id))
                continue;
            string slip = vars[1];
            int qty;
            if(!int.TryParse(vars[2], out qty))
                continue;
            string item = vars[3];
            string uom = vars[4];
            string desc = vars[5];
            data.Add(new Data { ID = id, Slip = vars[1], Quantity = qty, Desc = desc, Item = item, UOM = uom });
        }
    }

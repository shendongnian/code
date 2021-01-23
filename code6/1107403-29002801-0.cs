    ...
    da.Fill(ds); 
    foreach(DataRow r in ds[0].Rows)
    {
        List<DataRow> l = (from DataRow row in GridView1 where row.Item["Id"] == r.Item["Id"]).toList();
        if(l==0)
        {
            GridView GridView2 = new GridView();
            foreach(DataRow r2 in ds[0])
                if(r.Item["Id"]==r2.Item["Id"])
                    GridView2.Rows.Add(r2.Item["bFirstName"], r2.Item["etc..."]);
            GridView1.Rows.Add(r.Item["Id"], r.Item["etc..."], GridView2);
        }
    }

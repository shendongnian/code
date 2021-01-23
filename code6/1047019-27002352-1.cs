    var objects = outerObject.SelectMany(x => new {outer = x, inner = x.innerObject })
    
    foreach (var object in objects)
    {
        DataRow myDataRow = myDataTable.NewRow();
        myDataRow["Column1"] = object.outer.PropertyX;
        myDataRow["Column2"] = object.inner.PropertyY;
        myDataTable.Rows.Add(myDataRow);
    }

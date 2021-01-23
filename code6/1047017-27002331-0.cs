    var objects = outerObject.SelectMany(x => new { outer = x, inner = x.innerObject })
    
    foreach (var obj in objects)
    {
        DataRow myDataRow = myDataTable.NewRow();
        myDataRow["Column1"] = obj.outer.PropertyX; 
        myDataRow["Column2"] = obj.inner.PropertyY;
        myDataTable.Rows.Add(myDataRow);
    }

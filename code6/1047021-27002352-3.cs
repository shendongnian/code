    var objects = outerObject.SelectMany(x => x.InnerObject
        .Select(inner => new { Outer = x, Inner = inner } ));
    
    foreach (var obj in objects)
    {
        DataRow myDataRow = myDataTable.NewRow();
        myDataRow["Column1"] = obj.Outer.PropertyX;
        myDataRow["Column2"] = obj.Inner.PropertyY;
        myDataTable.Rows.Add(myDataRow);
    }

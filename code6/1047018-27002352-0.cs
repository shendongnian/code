    var objects = outerObject.SelectMany(x => 
    {
        var result = x.InnerObject;
        DataRow myDataRow = myDataTable.NewRow();
        myDataRow["Column1"] = x.PropertyX;
        myDataRow["Column2"] = result.PropertyY;
        myDataTable.Rows.Add(myDataRow);
        return result;
    }

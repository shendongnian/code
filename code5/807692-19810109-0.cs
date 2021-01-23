    List<CustomClass> cList= new List<CustomClass>();
    if(dtTable.row.count>0){
    cList=( from p in dtTable.AsEnumerable()
            select new CustomClass{
            propObj1= p.Field<OfType>("DatatableColumnName"),
            propObj2=p.FIeld<ofType>("DatabaseTableColumnName2")
    }).ToList();
    }

    //Add this somewhere in your project.
    class MyDataRow
    {
        public string Field {get; set;}
        public string Value {get; set;}
    }
    //back to your orginal function.
    public List<MyDataRow> GetInputMessage(Table table)
    {
        var data = table.CreateSet<SpecFlowData>(); //the ToList() that was here is not needed, just use the IEnumerable<SpecFlowData> or IQueryable<SpecFlowData> that CreateSet<SpecFlowData>() returns.
        var elements = (from item in data
                        //The two let clauses that where here are unessesary too.
                        select new MyDataRow {Field = item.Field, Value = item.Value}
                       ).ToList();
        return elements;
    }

    private List<MyObj> test(DataTable dt)
    {
        var convertedList = (from rw in dt.AsEnumerable()
                   select new MyObj()
                   {
                       ID = Convert.ToInt32(rw["ID"]),
                       FirstColumn = Convert.ToString(rw["FirstColumn"])
                       //etc...
                   }).ToList();
        return convertedList;
    }

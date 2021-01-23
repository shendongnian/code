    public class MyResultType {
        public string item { get; set; }
        public string item2 { get; set; }
        public string itemA { get; set; }
        public string itemB { get; set; }
    }
    var query = from l in DbConfig.Tables["table2"]
                join s in DbConfig.Tables["table1"] 
                on l.Field<string>("itemB") equals s.Field<string>("item1")
                where l.Field<string>("itemA") == name
                select new MyResultType { 
                    item = s.Field<string>("item"), 
                    item2 = s.Field<string>("item2"), 
                    itemA = l.Field<string>("itemA"), 
                    itemB = l.Field<string>("itemB") 
                };

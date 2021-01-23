    public class Foo
    {
        public string Fruit { get; set; }
        public string Animal { get; set; }
        public string Color { get; set; }
        public string Food { get; set; }
    }
    IEnumerable<Foo> query = null;
    switch (caseSwitch)
    {
        case 1:
            query = from x in Data
                    select new Foo { Fruit = x[0], Animal, x[2], Color = x[3], 
                        Food = x[4] };
             break;
         case 2:
             query = from x in Data
                    select new Foo { Fruit = x[7], Animal, x[4], Color = x[8],
                        Food = x[9] };
             break;
         default:
             // handle however you need to
    }

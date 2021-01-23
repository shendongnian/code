        public class SuperFunObject {
            public TimeSpan start { get; set; }
            public TimeSpan end { get; set; }
            public string selectedText { get; set; }
            public SuperFunObject(Timespan a, Timespan b, string text) {
                start = a;
                end = b;
                selectedText = text;
            }
        }
        List<SuperFunObject> funList = new List<SuperFunObject>();
        funList.Add(new SuperFunObject(TimeSpan.FromSeconds(0.0),TimeSpan.FromSeconds(20.0),"Hello"));
        dgvThing.DataSource = funList;
        ...
        ...
        //retrive your list
        List<SuperFunObject> getData = ((List<SuperFunObject>)dgvThing.DataSource);

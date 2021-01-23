    public class MyRow { // rename me
        public int Element { get; set; }
        public int Appearances { get; set; }
    }
    ....
    var rows = new List<MyRow>();
    for(...) {// loop over the two lists...
        rows.Add(new MyRow {
            Element =..., Appearances = ... });
    }
    rows.Sort((x,y) => y.Appearances.CompareTo(x.Appearances));

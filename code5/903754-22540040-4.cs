    public class LineList : List<Line>
    {
        public void Add(string sku, int qty)
        {
            this.Add(new Line(sku, qty));
        }
    }

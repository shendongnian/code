    public class Vertice
    {
        public int VerticeID { get; set; }
        [NotMapped]
        public Point[] Data
        {
            get
            {
                string[] rawInternalData = this.VerticeDataText.Split(';');
                Point[] dataResult = new Point[rawInternalData.Length / 2];
                int count = 0;
                rawInternalData.ToList().ForEach(p =>
                {
                    var pairArray = p.Split(',');
                    dataResult[count++] = new Point { X = double.Parse(pairArray[0]), Y = double.Parse(pairArray[1])};
                });
                return dataResult;
            }
            set
            {
                StringBuilder sb = new StringBuilder();
                value.ToList().ForEach(p => sb.AppendFormat("{0},{1};", p.X, p.Y));
                this.VerticeDataText = sb.ToString();
            }
        }
        public string VerticeDataText { get; set; }
    }

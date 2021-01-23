    public partial class LineChart : UserControl
    {
        public LineChart()
        {
            InitializeComponent();
            DataContext = this;
            myChart.Title = "hier könnte Ihr Text stehen!";
            this.Points = new List<DataPoint>();
            randomPoints();
        }
        public IList<DataPoint> Points { get; private set; }
        public void randomPoints()
        {
            Random rd = new Random();
            String myText = "";
            int anz = rd.Next(30, 60);
            for (int i = 0; i < anz; i++)
                myText += i + "," + rd.Next(0, 99) + ";";
            myText = myText.Substring(0, myText.Length - 1);
            String[] splitText = myText.Split(';');
            for (int i = 0; i < splitText.Length; i++)
            {
                String[] tmp = splitText[i].Split(',');
                Points.Add(new DataPoint(Double.Parse(tmp[0].Trim()), Double.Parse(tmp[1].Trim())));
            }
            while (Points.Count > anz)
                Points.RemoveAt(0);
            myChart.InvalidatePlot(true);
        }
    }

    public partial class Form1 : Form
    {
        Dictionary<DateTime,TimeSpan> lut = new Dictionary<DateTime, TimeSpan>(); 
        public Form1()
        {
            InitializeComponent();
        }
        static TimeZoneInfo edtZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
        static TimeZoneInfo gmtZone = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
        static TimeZoneInfo utcZone = TimeZoneInfo.FindSystemTimeZoneById("UTC");
        public static CultureInfo ci = CultureInfo.InvariantCulture;
        private void button5_Click(object sender, EventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            DateTime DT = new DateTime(2013, 01, 01);
            DateTime TDT;
            TimeSpan TS = new TimeSpan(5, 0, 0);
            for (int i = 0; i < 100000000; i++)
            {
                if (!lut.ContainsKey(DT))
                {
                    lut[DT] = DT - TimeZoneInfo.ConvertTime(DT, utcZone, edtZone);                    
                }
                TDT = DT - lut[DT];
            }
            sw.Stop();
            label1.Text = "Time taken: " + sw.ElapsedMilliseconds;
        }
    }

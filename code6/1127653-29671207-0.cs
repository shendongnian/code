    public class ChartDataFactory //whatever... or directly in the controller though i don't recommend it
    {
        public static IEnumerable<dataV1> GetChartData() //parameters ommited
        {
            List<dataV1> result = new List<dataV1>();
            //initialze connection/command/reader
            while (sqlReader.Read())
            {
                if (sqlReader["value"] != DBNull.Value) 
                {
                    result.Add(new dataV1((string)sqlReader["time"]));
                }
                else
                {
                    result.Add(new dataV2((string)sqlReader["time"],(double)sqlReader["value"]));
                }
            }
            
            return result;
        }
    }
    public class dataV1
    {
        public string time { get; set; }
        public dataV1(string Ptime)
        {
            this.time = Ptime;
        }
        public dataV1() { }
    }
    public class dataV2 : dataV1
    {
        public double value { get; set; }
        public dataV2(string Ptime, double Pvalue):base(Ptime)
        {
            this.value = Pvalue;
        }
        public dataV2() { }
    }

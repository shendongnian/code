     public class Graph
    {
        public List<ColInfo> cols { get; set; }
        public List<DataPointSet> rows { get; set; }    
    }
    public class ColInfo
    {
        
        public string label { get; set; }
        public string type { get; set; }
    }
    public class DataPointSet
    {
        public List<DataPoint> c { get; set; }
    }
    public class DataPoint
    {
        public string v { get; set; } // value    
        public string f { get; set; } // format
    }
    public string DemoPieChart()
        {
            Graph ChartData = new Graph();
            ChartData.cols = new List<ColInfo>();
            ChartData.rows = new List<DataPointSet>();
            ColInfo Col1 = new ColInfo();
            Col1.label = "Locality";
            Col1.type = "string";
            ColInfo Col2 = new ColInfo();
            Col2.label = "Frequency";
            Col2.type = "number";
            ChartData.cols.Add(Col1);
            ChartData.cols.Add(Col2);
            //Loop your data entry from both array
            string[] locality = new string[] { "Loc_A", "Loc_B", "Loc_C", "Loc_D", };
            long[] frequency = new long[] { 10, 20, 10, 80 };
            for (int i = 0; i < locality.Length; i++)
            {
                DataPointSet Row = new DataPointSet();
                Row.c = new List<DataPoint>();
                DataPoint p1 = new DataPoint();
                p1.v = locality[i];
                p1.f = null;
                DataPoint p2 = new DataPoint();
                p2.v =  frequency[i].ToString("F")  ;           
                p2.f = null;
                Row.c.Add(p1);
                Row.c.Add(p2);
                ChartData.rows.Add(Row);          
            }
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            string jsonobj = jsSerializer.Serialize(ChartData);           
            return jsonobj;
          }

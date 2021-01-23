    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Linq;
    
    namespace weatherxml
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xmlData = @"<Observations><Observation><Station>ADELONG POST OFFICE</Station><DateTime>2010-09-02T00:00:00</DateTime><Temperature>19.212989033764689</Temperature></Observation><Observation><Station>ADELONG POST OFFICE</Station><DateTime>2010-09-01T00:00:00</DateTime><Temperature>28.529448969536205</Temperature></Observation><Observation><Station>ALBURY AIRPORT</Station><DateTime>2010-09-01T00:00:00</DateTime><Temperature>34.687027630716109</Temperature></Observation><Observation><Station>ALBURY AIRPORT AWS</Station><DateTime>2010-09-01T00:00:00</DateTime><Temperature>28.131385570453197</Temperature></Observation></Observations>";
                var stl = new List<Station>();
                using (DataSet ds = new DataSet())
                {
                    ds.ReadXml(new StringReader(xmlData));
    
                    //i want proper types, not strings
                    DataColumn dc = ds.Tables[0].Columns.Add("dt", typeof(DateTime));
                    dc.Expression = "DateTime";
                    dc = ds.Tables[0].Columns.Add("temp", typeof(Decimal));
                    dc.Expression = "Temperature";
                    
                    //group by
                    var result = ds.Tables[0].AsEnumerable().GroupBy(a => a.Field<string>("Station")).Select(g => g.OrderByDescending(a => a.Field<DateTime>("dt")));
                    
                    //create result
                    foreach(var i in result)
                    {
                        var fi = i.First();
                        stl.Add(new Station() { Name = fi.Field<string>("Station"), LastTemperature = fi.Field<decimal>("temp"), MostRecentDate = fi.Field<DateTime>("dt") });
                    }
                    //here the stationList (stl) has info for all stations
                }
                Console.ReadLine();
            }
        }
    
        public class Station
        {
            public string Name { get; set; }
            public DateTime MostRecentDate { get; set; }
            public decimal LastTemperature { get; set; }
    
        }
    }
    

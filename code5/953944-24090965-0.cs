    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Linq;
    
    static class Module1
    {
    
        const int NUMBERCOLUMNMAX = 1000;
        const int VALUEMAX = 100;
        const int SAMPLEDATASIZE = 100000; // how many rows to populate the DataTable with.
        const int NBINS = 200; // equivalent to quantity of ranges
    
        static Random rand = new Random();
        static DataTable dt;
    
        static List<Range> ranges;
    
        public class Range
        {
            public int LowerRangeInclusive { get; set; }
            public int UpperRangeExclusive { get; set; }
            public double Average { get; set; }
        }
    
        public static DataTable GetData()
        {
            // create DataTable
            DataTable dt = new DataTable();
            DataColumn dcNum = new DataColumn
            {
                ColumnName = "numberColumn",
                DataType = Type.GetType("System.Int32")
            };
            DataColumn dcVal = new DataColumn
            {
                ColumnName = "Value",
                DataType = Type.GetType("System.Int32")
            };
            dt.Columns.Add(dcNum);
            dt.Columns.Add(dcVal);
    
            // populate DataTable
            for (int i = 1; i <= SAMPLEDATASIZE; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = rand.Next(1, NUMBERCOLUMNMAX + 1);
                dr[1] = rand.Next(1, VALUEMAX + 1);
                dt.Rows.Add(dr);
            }
    
            return dt;
    
        }
    
        public static List<Range> GetRanges()
        {
            ranges = new List<Range>();
            int nRanges = NBINS;
    
            for (int i = 0; i < nRanges; i++)
            {
                Range thisRange = new Range
                {
                    LowerRangeInclusive = Convert.ToInt32(Math.Floor(Convert.ToDouble(NUMBERCOLUMNMAX) * i / nRanges)),
                    UpperRangeExclusive = Convert.ToInt32(Math.Floor(Convert.ToDouble(NUMBERCOLUMNMAX) * (i + 1) / nRanges))
                };
                ranges.Add(thisRange);
            }
    
            return ranges;
    
        }
    
        public static void SetAverages(List<Range> ranges, DataTable dt)
        {
            int nRanges = ranges.Count;
            List<int>[] bins = new List<int>[nRanges];
            
            for (int i = 0; i < nRanges; i++)
            {
                bins[i] = new List<int>();
            }
    
            int numCol = dt.Columns["numberColumn"].Ordinal;
            int valCol = dt.Columns["Value"].Ordinal;
    
            foreach (DataRow dr in dt.Rows)
            {
                for (int i = 0; i < nRanges; i++)
                {
                    if (Convert.ToInt32(dr[numCol]) >= ranges[i].LowerRangeInclusive && Convert.ToInt32(dr[numCol]) < ranges[i].UpperRangeExclusive)
                    {
                        bins[i].Add(Convert.ToInt32(dr[valCol]));
                        break;
                    }
                }
            }
    
            //TODO: Do something meaningful in the case where ranges(i).Count == 0 instead of the average being zero.
            for (int i = 0; i < nRanges; i++)
            {
                if (bins[i].Count > 0)
                {
                    ranges[i].Average = bins[i].Average();
                }
            }
    
        }
    
        public static void Main()
        {
            Console.Write("Init...");
            dt = GetData();
            ranges = GetRanges();
            Console.WriteLine("done.");
    
            // Show ranges
            //foreach (Range r in ranges)
            //{
            //    Console.WriteLine(String.Format("{0,4} {1,5}", r.LowerRangeInclusive, r.UpperRangeExclusive));
            //}
    
            // Show datarows
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    Console.WriteLine("{0,4} {1,5}", dt.Rows[i][0], dt.Rows[i][1]);
            //}
    
            //Time it so that comparisons can be made to other methods.
            Stopwatch sw = new Stopwatch();
            sw.Start();
            SetAverages(ranges, dt);
            sw.Stop();
            Console.WriteLine(string.Format("{0} rows processed in {1} bins in {2}ms.", dt.Rows.Count, NBINS, sw.ElapsedMilliseconds));
    
            // Show the results
            foreach (Range r in ranges)
            {
                Console.WriteLine(string.Format("[{0},{1}): {2}", r.LowerRangeInclusive, r.UpperRangeExclusive, r.Average));
            }
    
            Console.ReadLine();
    
        }
    
    }
    
    

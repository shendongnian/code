    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace chart_binding
    {
    public partial class Form1 : Form
    {
        TrendData td = new TrendData();
        TrendData td2 = new TrendData();
        public Form1()
        {
            InitializeComponent();
            //trend data 1
            DataPoint dt1 = new DataPoint();
            dt1.DateTime = DateTime.Now;
            dt1.Value = 100;
            DataPoint dt2 = new DataPoint();
            dt2.DateTime = DateTime.Now.AddDays(+1);
            dt2.Value = 200;
            td.Add(dt1);
            td.Add(dt2);
            //trend data 2
            DataPoint dt11 = new DataPoint();
            dt11.DateTime = DateTime.Now;
            dt11.Value = 50;
            DataPoint dt22 = new DataPoint();
            dt22.DateTime = DateTime.Now.AddDays(+1);
            dt22.Value = 70;
            td2.Add(dt11);
            td2.Add(dt22);
            
            chart1.Series.Add("series2");
            chart1.Series[0].Points.DataBindXY(td.Select(x => x.DateTime).ToList<DateTime>(), td.Select(x => x.Value).ToList<double>());
            chart1.Series[1].Points.DataBindXY(td2.Select(x => x.DateTime).ToList<DateTime>(), td2.Select(x => x.Value).ToList<double>());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //trend data1
            DataPoint dt3 = new DataPoint();
            dt3.DateTime = DateTime.Now.AddDays(2);
            dt3.Value = 300;
            td.Add(dt3);
            //trend data2
            DataPoint dt33 = new DataPoint();
            dt33.DateTime = DateTime.Now.AddDays(2);
            dt33.Value = 150;
            td2.Add(dt33);
            //no auto-update, have to call this code every time you add something to TrendData
            chart1.Series[0].Points.DataBindXY(td.Select(x => x.DateTime).ToList<DateTime>(), td.Select(x => x.Value).ToList<double>());
            chart1.Series[1].Points.DataBindXY(td2.Select(x => x.DateTime).ToList<DateTime>(), td2.Select(x => x.Value).ToList<double>());
        }
    }
    class DataPoint
    {
        public DateTime DateTime { get; set; }
        public double Value { get; set; }
    }
    class TrendData : IList<DataPoint>
    {
        public List<DataPoint> myPoints = new List<DataPoint>();
        public void Add(DataPoint item)
        {
            myPoints.Add(item);
        }
        public int IndexOf(DataPoint item)
        {
            throw new NotImplementedException();
        }
        public void Insert(int index, DataPoint item)
        {
            throw new NotImplementedException();
        }
        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }
        public DataPoint this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public void Clear()
        {
            throw new NotImplementedException();
        }
        public bool Contains(DataPoint item)
        {
            throw new NotImplementedException();
        }
        public void CopyTo(DataPoint[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }
        public int Count
        {
            get { throw new NotImplementedException(); }
        }
        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }
        public bool Remove(DataPoint item)
        {
            throw new NotImplementedException();
        }
        public IEnumerator<DataPoint> GetEnumerator()
        {
            return myPoints.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
    }

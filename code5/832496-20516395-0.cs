    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using DevExpress.XtraCharts;
    namespace WindowsApplication53
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                PopulateTable();
                pivotGridControl1.RefreshData();
                pivotGridControl1.BestFit();
            }
            private void PopulateTable()
            {
                DataTable myTable = dataSet1.Tables["Data"];
                myTable.Rows.Add(new object[] { "Aaa", DateTime.Today, 7 });
                myTable.Rows.Add(new object[] { "Aaa", DateTime.Today.AddDays(1), 4 });
                myTable.Rows.Add(new object[] { "Bbb", DateTime.Today, 12 });
                myTable.Rows.Add(new object[] { "Bbb", DateTime.Today.AddDays(1), 14 });
                myTable.Rows.Add(new object[] { "Ccc", DateTime.Today, 11 });
                myTable.Rows.Add(new object[] { "Ccc", DateTime.Today.AddDays(1), 10 });
                myTable.Rows.Add(new object[] { "Aaa", DateTime.Today.AddYears(1), 4 });
                myTable.Rows.Add(new object[] { "Aaa", DateTime.Today.AddYears(1).AddDays(1), 2 });
                myTable.Rows.Add(new object[] { "Bbb", DateTime.Today.AddYears(1), 3 });
                myTable.Rows.Add(new object[] { "Bbb", DateTime.Today.AddDays(1).AddYears(1), 1 });
                myTable.Rows.Add(new object[] { "Ccc", DateTime.Today.AddYears(1), 8 });
                myTable.Rows.Add(new object[] { "Ccc", DateTime.Today.AddDays(1).AddYears(1), 22 });
            }
            private void pivotGridControl1_CustomChartDataSourceData(object sender, DevExpress.XtraPivotGrid.PivotCustomChartDataSourceDataEventArgs e)
            {
            }
            List<Series> list = new List<Series>();
            private void chartControl1_BoundDataChanged(object sender, EventArgs e)
            {
                ChartControl chart = (ChartControl)sender;
                if (chart.Series.Count < 1) return;
                for (int i = chart.Series.Count - 1; i >= 0; i--)
                {
                    Series s = chart.Series[i];
                    foreach (SeriesPoint point in s.Points)
                    {
                        double width = point.Values[0];
                        point.Values[0] = GetPreviousSeriesSummary(chart, i, point.Argument);
                        point.Values[1] = point.Values[0] + width;
                    }
                }
            }
            private double GetPreviousSeriesSummary(ChartControl chart, int seriesIndex, string argument)
            {
                double summaryValue = 0;
                for (int i = 0; i < seriesIndex; i++)
                {
                    Series s = chart.Series[i];
                    foreach (SeriesPoint point in s.Points)
                    {
                        if (Equals(point.Argument, argument))
                            summaryValue += point.Values[0];
                    }
                }
                return summaryValue;
            }
            private void chartControl1_CustomDrawSeriesPoint(object sender, CustomDrawSeriesPointEventArgs e)
            {
            }
        }
    }

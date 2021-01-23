    #region showValueInChart
            q1 = q1.OrderByDescending(n => n.Score).ToList();
            chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            foreach (var item in chart1.Series)
            {
                chart1.Series[item.Name.ToString()].Points.Clear();
            }
            //var q0 = q1.Where(n => n.OperationName == item.Name.ToString()).OrderByDescending(n => n.Score).ToList();
            //if (q0 != null)
            //{
                //q0 = q0.OrderByDescending(n => n.Score).ToList();
                foreach (var item1 in q1)
                {
                    chart1.Series[item1.OperationName].Points.AddXY(item1.personName.ToString(), (int)(item1.Score));
                    chart1.AlignDataPointsByAxisLabel();
                }
            //}
            chart1.ChartAreas["ChartArea1"].AxisY.LabelStyle.Enabled = true;
            #endregion

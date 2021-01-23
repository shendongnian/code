        private void Chart_Customize(object sender, EventArgs e)
        {
            List<CustomLabel> list = new List<CustomLabel>();
            System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex("^\\d+$");
            
            foreach (CustomLabel l in chart.ChartAreas[0].AxisY.CustomLabels)
            {
                if(!r.IsMatch(l.Text))
                {
                    list.Add(l);
                } 
            }
            if (list.Count > 0)
            {
                foreach (CustomLabel l in list)
                    chart.ChartAreas[0].AxisY.CustomLabels.Remove(l);
                chart.ChartAreas[0].AxisY.Interval = 1;
            }
        }

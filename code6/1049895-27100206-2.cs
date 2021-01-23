        protected void txtendtime_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime startTime, endTime;
                startTime = Convert.ToDateTime(txtstrtime.Text);
                endTime = Convert.ToDateTime(txtendtime.Text);
                if (startTime > endTime)
                    endTime = endTime.AddDays(1);
                TimeSpan span = (toDate - fromDate);
                double actualHours = Math.Round(span.TotalHours, 2);
                txtduration.Text = Convert.ToString(actualHours);
                txtduration.Focus();
            }
            catch
            {
            }
        }

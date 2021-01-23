        protected void txtendtime_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime startTime, endTime;
                startTime = Convert.ToDateTime(txtstrtime.Text);
                endTime = Convert.ToDateTime(txtendtime.Text);
                TimeSpan span = (toDate - fromDate);
                decimal actualHours = Math.Round(span.TotalHours, 2);
                txtduration.Text = Convert.ToString(actualHours);
                txtduration.Focus();
            }
            catch
            {
            }
        }

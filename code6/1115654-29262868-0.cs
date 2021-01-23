            try
            {
                woEndTime = DateTime.Now;
                difference = woEndTime - woStartTime;
                long dTime = Convert.ToInt64(difference.Ticks);
                average = dTime / Scanned;
                TimeSpan averageTimeSpan = new TimeSpan(average);                
                lblError.Text = averageTimeSpan.ToString(@"hh\:mm\:ss"); // display to verify results
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

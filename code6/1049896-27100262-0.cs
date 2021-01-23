                DateTime startTime, endTime;
                TimeSpan timeDiff;
                startTime = Convert.ToDateTime(txtstrtime.Text);;
                endTime = Convert.ToDateTime(txtendtime.Text);
                if (startTime > endTime)
                {
                    timeDiff = new TimeSpan(startTime.Ticks - endTime.Ticks);
                }
                else
                {
                    timeDiff = new TimeSpan(endTime.Ticks - startTime.Ticks);
                }
                txtduration.Text = Convert.ToString(timeDiff );

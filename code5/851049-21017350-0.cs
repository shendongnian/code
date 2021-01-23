    try
            {
                DateTime firstDt;
                DateTime lastDt;
                if (DateTime.TryParseExact(First.Text, "yyyy-MM-dd HH-mm-ss-fff", CultureInfo.InvariantCulture, DateTimeStyles.None, out firstDt)
                       && DateTime.TryParseExact(Last.Text, "yyyy-MM-dd HH-mm-ss-fff", CultureInfo.InvariantCulture, DateTimeStyles.None, out lastDt))
                {
                    TimeSpan difference = lastDt- firstDt;
                    Console.WriteLine(difference);
                    CalcDiff.Text = "DelayAudio(" + difference.TotalSeconds.ToString("F3") + ")";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("TimeSpan Calculate: " + ex.Message);
            }

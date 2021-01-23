                DateTime firstDt;
                DateTime lastDt;
                DateTime.TryParse(First.Text, out firstDt);
                DateTime.TryParse(Last.Text, out lastDt);
                TimeSpan difference = lastDt - firstDt;
                CalcDiff.Text = "DelayAudio(" + difference.ToString()+ ")";

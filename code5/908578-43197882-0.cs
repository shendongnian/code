            zoomTrackBar.Minimum = 25;
            zoomTrackBar.Maximum = 400;
            zoomTrackBar.Value = 100;
            zoomTrackBar.TickFrequency = 25;
        }
        #endregion
        private void zoomTrackBar_Scroll(object sender, EventArgs e)
        {
            int value = (sender as TrackBar).Value;
            double indexDbl = (value * 1.0) / zoomTrackBar.TickFrequency;
            int index = Convert.ToInt32(Math.Round(indexDbl));
            zoomTrackBar.Value = zoomTrackBar.TickFrequency * index;
            label2.Text = zoomTrackBar.Value.ToString();
        }

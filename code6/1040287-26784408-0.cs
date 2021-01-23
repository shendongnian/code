        private void button27_Click(object sender, EventArgs e)
        {
            Debug.WriteLine(string.Format("{0}:{1}", 
                                GetHours(1935),
                                GetRemainderMinutes(1935)));
        }
        private int GetHours(int minutes)
        {
            // Get how many hours are contained in the total minutes
            return minutes / 60;
        }
        private object GetRemainderMinutes(int minutes)
        {
            // Get the remaining amount that couldn't be divided into hours.
            return minutes % 60;
        }

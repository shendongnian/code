        void example()
        {
            var t = TimeSpan.FromSeconds(14400);
            for(int i = 0; i < 145; i++)
            {
                t.Add(TimeSpan.FromSeconds(300));
                string time = string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);
                Chart1.Series["TARGET"].Points.AddXY(time, 0);
            }
        }

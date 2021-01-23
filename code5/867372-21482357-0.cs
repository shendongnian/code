        private void MeasureTime(Action m)
        {
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            m();
            sw.Stop();
            ShowTakenTime(sw.ElapsedMilliseconds);
        }

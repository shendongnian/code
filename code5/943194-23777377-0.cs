    public class MethodExecutions
    {
        private int _excCount = 0;
        private Int64 _totalExcTime = 0;
        private int _excMaxTimeTotalMilliseconds = 0;
        private int _excMinTimeTotalMilliseconds = int.MaxValue;
        private int _failCount = 0;
        public void Add(int excTime, bool isFail)
        {
            _excCount += 1;
            _totalExcTime += excTime;
            if (excTime > _excMaxTimeTotalMilliseconds)
                _excMaxTimeTotalMilliseconds = excTime;
            if (excTime < _excMinTimeTotalMilliseconds)
                _excMinTimeTotalMilliseconds = excTime;
            if (isFail)
                _failCount++;
        }
        public void Summarize(out int avgTime, out int minTime, out int maxTime, out int failCount)
        {
            avgTime = (int) Math.Round((double) _totalExcTime / _excCount);
            minTime = _excMinTimeTotalMilliseconds;
            maxTime = _excMaxTimeTotalMilliseconds;
            failCount = _failCount;
        }
    }

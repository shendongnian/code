    private class MutingReader : IWaveProvider
    {
        private TimeSpan _start;
        private TimeSpan _end;
        private WaveStream _stream;
    
        // constructor
        public MutingReader(WaveStream stream, TimeSpan start, TimeSpan end)
        {
            _stream = stream;
            _start = start;
            _end = end;
        }  
    
        // gets called each time the WaveOut needs more bytes
        public int Read(byte[] array, int offset, int count)
        {
            Debug.WriteLine(_stream.CurrentTime);
            var samples = _stream.Read(array, offset, count);
            // if we are between our Start and End Time stamps
            if (_stream.CurrentTime > _start &&
                _stream.CurrentTime < _end)
            {
                // silence by only returning zeroes in the array
                for (int i = 0; i < count; i++)
                {
                    array[i + offset] = 0;
                }
            }
            return samples;
        }
    
        #region IWaveProvider Members
        public WaveFormat WaveFormat
        {
            get { return _stream.WaveFormat; }
        }
        #endregion
    }

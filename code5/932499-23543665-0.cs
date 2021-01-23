    class Sample
    {
        public DateTime EventTime { get; set; }
        public decimal Value { get; set; }
    }
    List<Sample> _samples = new List<Sample>();
    ReaderWriterLockSlim _samplesLock = new ReaderWriterLockSlim();
    // to get items after a particular date
    List<Sample> GetSamplesAfterDate(DateTime dt)
    {
        _samplesLock.EnterReadLock();
        try
        {
            return _samples.Where(s => s.EventTime >= dt).ToList();
        }
        finally
        {
            _samplesLock.ExitReadLock();
        }
    }

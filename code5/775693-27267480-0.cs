        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
       protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.performanceCounters != null)
                {
                    foreach (PerformanceCounter counter in this.performanceCounters.Values)
                    {
                        counter.RemoveInstance();
                        counter.Dispose();
                    }
                    this.performanceCounters = null;
                }
            }
        }

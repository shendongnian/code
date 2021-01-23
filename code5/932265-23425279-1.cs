    public class ReportService : IDisposable
    {
        private bool disposedValue = false;
        private Entities _modelContext = new Entities();
        public DataTable GetData(int startRecord, int maxRecords)
        {
		...
		// use _modelContext and process the data
            return outputTable;
        }
        public List<int> GetWeeks()
        {
		...
		// use _modelContext and process the data
        }
        public int GetPageCount()
        {
		...
		// use _modelContext and process the data
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    _modelContext.Dispose();
                }
            }
            this.disposedValue = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

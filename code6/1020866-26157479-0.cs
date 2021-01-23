    public class BatchFilter
    {
        private List<Batch> _batches;
        public BatchFilter(List<Batch> batches)
        {
             _batches = batches;
        }
    
        public List<Batch> BatchesCompleted { 
       get { 
       return _batches.Where(x => x.Status == BatchManager.BatchStatus.Completed.ToString()).ToList(); } }
    }
    
    class BatchManager
    {
        public BatchFilter PropertiesGroup { get { return new BatchQuery(Batches); }}
        // ...
    }
        

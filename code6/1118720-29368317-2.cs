    public class Context {
        //...other properties
        [ForeignKey("RemoteBenchmark")]
        public int RemoteBenchmarkId { get; set; }
        public Benchmark RemoteBenchmark { get; set; }
        
        [ForeignKey("DataCenterBenchmark")]
        public int DataCenterBenchmarkId { get; set; }
        public Benchmark DataCenterBenchmark { get; set; }
        
        [ForeignKey("IISBenchmark")]
        public int IISBenchmarkId { get; set; }
        public Benchmark IISBenchmark { get; set; }
        
        [ForeignKey("LocalBenchmark")]
        public int LocalBenchmarkId { get; set; }
        public Benchmark LocalBenchmark { get; set; }
        }

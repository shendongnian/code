    public class Context {
        //...other properties
        public int RemoteBenchmarkId { get; set; }
        [ForeignKey("RemoteBenchmarkId")]
        public Benchmark RemoteBenchmark { get; set; }
        }

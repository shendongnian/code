    public class Context {
        //...other properties
        [ForeignKey("RemoteBenchmark")]
        public int RemoteBenchmarkId { get; set; }
        public Benchmark RemoteBenchmark { get; set; }
        }

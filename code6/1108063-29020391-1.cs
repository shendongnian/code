    // nested helper class
    public class PostParams {
        public int Value { get; set; }
    } 
    public string Post(PostParams parameters) {
        return parameters.Value.ToString();
    }

    using ServiceStack.Text;
    using ServiceStack.DataAnnotations;
    public sealed class SomeObject
    {
        [Alias("expand")]
        public string Expand { get; set; }
        [Alias("projects")]
        public List<string> Projects {get; set; }
    }

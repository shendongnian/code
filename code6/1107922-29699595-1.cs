    public partial class BilingualString
    {
        public string English { get; set; }
        public string French { get; set; }
    }
    
    public class ClassWithShortDescription
    {
        [MaxLengthBilingualString(20)]
        public BilingualString Description { get; set; }
    }
    
    public class ClassWithLongDescription
    {
        [MaxLengthBilingualString(200)]
        public BilingualString Description { get; set; }
    }

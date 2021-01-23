    public class ClassWithShortDescription
    {
        [MaxLengthForEnglish(20)]
        [MaxLengthForFrench(25)]
        public BilingualString Description { get; set; }
    }
    public class ClassWithLongDescription
    {
        [MaxLengthForEnglish(200)]
        [MaxLengthForFrench(250)]
        public BilingualString Description { get; set; }
    }

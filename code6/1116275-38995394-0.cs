    public class Foo {
        [Key]
        public int Id { get; set; }
        public BarEnum BarId { get; set; }
        [ForeignKey(nameof(BarId))]
        public Bar Bar { get; set; }
    }
    public class Bar {
        [Key]
        public int Id { get; set; }
    }
    public enum BarEnum {
        Type1,
        Type2
    }

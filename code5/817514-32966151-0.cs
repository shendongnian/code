    public class FooDTO
        {
            [Required]
            public FooEnum FooEnum { get; set; }
            //.. other attributes omitted
        }
    }
    public enum FooEnum
    {
        Foo, Bar
    }

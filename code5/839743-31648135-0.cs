    public class Test
        {
            public Test()
            {
                _strings = new List<string>
                {
                    "test",
                    "test2",
                    "test3",
                    "test4"
                };
            }
    
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
    
            private List<String> _strings { get; set; }
    
            public List<string> Strings
            {
                get { return _strings; }
                set { _strings = value; }
            }
    
            [Required]
            public string StringsAsString
            {
                get { return _strings.Aggregate((c, n) => c + "," + n); }
                set { _strings = value.Split(',').ToList(); }
            }
        }

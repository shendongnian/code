    public class Test
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column]
        [Required]
        private String StringsAsStrings { get; set; }
        public List<String> Strings
        {
            get { return StringsAsStrings.Split(',').ToList(); }
            set
            {
                StringsAsStrings = String.Join(",", value);
            }
        }
        public Test()
        {
            Strings = new List<string>
            {
                "test",
                "test2",
                "test3",
                "test4"
            };
        }
    }

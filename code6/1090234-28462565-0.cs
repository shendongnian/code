    public class Company
        {
            public int Id { get; set; }
            [Required, StringLength(100)]
            public string Name { get; set; }
            public DbGeography Location { get; set; }
            public bool ColumnToConvert { get; set; }
        }

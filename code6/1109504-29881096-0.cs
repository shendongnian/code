         [TableName("Keyphrase")]
         public class Keyphrase
         {
            [PrimaryKeyColumn(AutoIncrement = true)]
            public int Id { get; set; }
            public string Name { get; set; }
            public string Phrase { get; set; }
            public string Link { get; set; }
            public override string ToString()
            {
                return Name;
            }
        }

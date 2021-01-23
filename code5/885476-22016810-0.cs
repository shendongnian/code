        public class teams
        {
          [PrimaryKey, AutoIncrement]
           public int id { get; set; }
          public string team_Name { get; set; }
        }
        public class appendList
         {
           [PrimaryKey, AutoIncrement]
           public int id { get; set; }
           public string team_Name { get; set; }
           public string teamImage
         }

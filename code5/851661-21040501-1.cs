        public class Title
        {
            public int Id   //or TitleId if you prefer
    
            public int GenreId { get; set; }
    
            public virtual Genre Genre { get; set; }
        }
    
     
       public class Genre
       {
            public int Id { get; set; }   //or GenreId if you prefer
    
            ["Required"]
            public string Name{ get; set; }
    
            public string Keywords { get; set; }
       }

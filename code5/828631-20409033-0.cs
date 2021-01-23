    namespace Models.Entities
    {
        public class News
        {
        //your code
        public static implicit operator Models.Import.News(News value)
        {
            return new Import.News() 
            { 
                Title = value.Title,
                //and so on
            };
        }  
    }
    namespace Models.Import
    {
        public class News
        {
            //your codes
            public static implicit operator Models.Entities.News(News value)
            {
                return new Entities.News() 
                {
                    Title = value.Title,
                    //and so on 
                };
            }
        }
     }

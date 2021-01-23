    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    
    namespace sfPerformance
    {
        class MoviesDynamicOrderBy
        {
            static void Main(string[] args)
            {
                IQueryable<MovieData> MovieNameList = new List<MovieData>() { 
                new MovieData {Name = "Star Wars" , Rating = 7, Language = "Hollywood"},
                new MovieData {Name = "The Godfather" , Rating = 7, Language = "Hollywood"},
                new MovieData {Name = "The Lord Of The Rings" , Rating = 8, Language = "Hollywood"},
                new MovieData {Name = "Titanic" , Rating = 10, Language = "Hollywood"},
                new MovieData {Name = "Gone With The Wind" , Rating = 9, Language = "Hollywood"}            
                }.AsQueryable();
    
                //Ascending default
                MoviesDynamicOrderBy obj = new MoviesDynamicOrderBy();
                var result = obj.StudentOrderByColumn<MovieData>("Name", MovieNameList);
                 
                foreach (var item in result)
                {
                    Console.WriteLine(item.Name);
                }
    
                Console.WriteLine(Environment.NewLine);
    
                //Descending  
                var descendingResult = obj.StudentOrderByColumn<MovieData>("Name", MovieNameList, true);
    
                foreach (var item in descendingResult)
                {
                    Console.WriteLine(item.Name);
                } 
    
                if (System.Diagnostics.Debugger.IsAttached)
                    Console.Read(); 
            }
    
            public IOrderedQueryable<MovieData> StudentOrderByColumn<T>(string orderbycolumn, IQueryable<MovieData> values, bool isDescending = false) 
            { 
                PropertyInfo pi = typeof(MovieData).GetProperty(orderbycolumn);
                IOrderedQueryable<MovieData> sortedMovies;
                if(isDescending)
                 sortedMovies = values.OrderByDescending(x => pi.GetValue(x, null)); 
                else 
                 sortedMovies = values.OrderBy(x => pi.GetValue(x, null));
    
                return sortedMovies;
            }
        }
         
        public class MovieData
        {
            public string Name { get; set; }
            public int Rating { get; set; }
            public string Language { get; set; }
        }
    }

    public class Test
        {
            public Cars MyCars { get; set; }
            public enum Cars
            {
                [Display(Name = @"Car #1")]
                Car1 = 1,
                [Display(Name = @"Car #2")]
                Car2 = 2,
                [Display(Name = @"Car #3")]
                Car3 = 3
            }
    
        }

    using System;
    using System.Collections.Generic;
    using Aviato.Models;
    
    namespace Aviato.ViewModel
    {
        public class StampingModel
        {
            public List<Stamping> Stampings { get; set; }
            public int Year { get; set; }
            public int WeekNo { get; set; }
        }
    }

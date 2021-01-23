    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;  //added this line
    using System.Linq;
    using System.Web;
    
    namespace glostars.Models
    {
        public class WeeklyTagged
        {
            [Key]                                   //and this line
            public int TaggedId { get; set; }          
        }
    }

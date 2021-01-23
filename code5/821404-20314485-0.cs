    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    
    namespace MvcApplication1.Models
    {
        [Table("studentdetails")]
        public class student
        {
            [Key]
            public int RollNo { get; set; }
    
            public string Name { get; set; }
            
            public string Stream { get; set; }
            
            public string Div { get; set; }
        }
    }

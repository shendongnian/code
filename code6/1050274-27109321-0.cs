    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations;
    namespace MVCImportExcel.Models
    {
        public class MyViewModel
        {
            [Required]
            public HttpPostedFileBase MyExcelFile { get; set; }
            public string MSExcelTable { get; set; }
        }
    }

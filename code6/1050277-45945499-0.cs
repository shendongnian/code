    namespace ExcelUploadFileDemo.Models
        {
            public class UploadFile
            {
                [Required]
                public HttpPostedFileBase ExcelFile { get; set; }
            }
        }

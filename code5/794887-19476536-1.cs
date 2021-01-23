    public class UploadModel
        {
            [Required(ErrorMessage=("You have not selected a file"))]
            public HttpPostedFileBase File { get; set; }
            [Required(ErrorMessage = "Please enter a title")]
            [StringLength(50)]
            public string Title { get; set; }
            [StringLength(400)]
            public string Description { get; set; }
        }

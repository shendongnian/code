    public class UploadModel
    {
        [Required(ErrorMessage="Please choose a file to upload.")]
        public HttpPostedFileBase Photo { get; set; }
    }

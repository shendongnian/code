    public class ViewModel
    {
        [Required, Microsoft.Web.Mvc.FileExtensions(Extensions = "txt", ErrorMessage = "Specify a txt file.")]
        public HttpPostedFileBase File { get; set; }
    }

    public class UploadFileModel //: IEnumerable
    {
        [FileSize(10240)]
        [FileTypes("jpg,jpeg,png,pdf")]
        public HttpPostedFileBase File { get; set; }
    }

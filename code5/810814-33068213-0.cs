    public class FileSizeValiadtor : FormCustomValidator
    {
        protected override bool EvaluateIsValid()
        {
            bool isValid = false;
            var fileUpload = this.FindControl(base.ControlToValidate) as FileUpload;
            if (fileUpload != null && fileUpload.HasFile)
            {
                int fileSizeLimitinBytes = GetFileSizeLimit();
                int sizeInBytes = fileUpload.PostedFile.ContentLength;
                isValid = (sizeInBytes <= fileSizeLimitinBytes);
            }
            return isValid;
        }

    public class SforceService
    {
        public SforceService() {
            this.Url = global::email2case_winForm.Properties.Settings.Default.email2case_sforce_SforceService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
    }
    public class SforceServiceSandbox
    {
        public SforceServiceSandbox()
        {
            this.Url = global::email2case_winForm.Properties.Settings.Default.SForceService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true))
            {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else
            {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
    }

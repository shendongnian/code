    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void ButtonCreateInstallment_Click(object sender, EventArgs e)
        {
            CreateInstallment = true;
        }
        protected void ButtonSaveInstallment_Click(object sender, EventArgs e)
        {
            if (CreateInstallment == true)
            {
              // create installment
            }
        }
        private bool CreateInstallment
        {
            get
            {
                bool? createInstallment = ViewState["createInstallment"] as bool?;
                return createInstallment.HasValue ? createInstallment.Value : false;
            }
            set
            {
                ViewState["createInstallment"] = value;
            }
        }
    }

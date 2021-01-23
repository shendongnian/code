     using System.Web.UI.HtmlControls;
    public partial class MyMasterPage : System.Web.UI.MasterPage
    {
        public HtmlGenericControl BodyTag
        {
            get
            {
                return MasterPageBodyTag;
            }
            set
            {
                MasterPageBodyTag = value;
            }
        }

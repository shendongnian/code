    using System.Web.UI.WebControls;
    namespace MyControls{
    public class MyGrid : GridView
    {
        public override string ClientID
        {
            get
            {
                return ID;
            }
        }
    }}

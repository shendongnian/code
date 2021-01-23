    namespace WebLll.ApiPayment.BusinessObject
    {
        public class clsWebLllAPI : clsBaseApi
        {
            public void Initialize(api_rule_setup obj)
            {
                ClsUser clsUser = new ClsUser ();
                var lst = clsUser.BRIlstTxn;
            }
    
        }
    }

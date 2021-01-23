    // ClsUser.cs
    namespace WebLll.ApiPayment.BusinessObject
    {
        public class ClsUser
        {
            Data.MyEntity db = new Data.MyEntity("MyEntity1");
    
            private List<Data.GetPaymentRslt> BRIlstTxn = db.GetPayment(obj.PaymentCode, dtFrom, dtTo, obj.PaymentMode).ToList(); 
            // Only GET . Provide protection over setting it
            public  List<Data.GetPaymentRslt> brIlstTxn{
               get{
                   return BRIlstTxn;
               }
            }
    
            //... remaining code
        }
    }
    // clsWebLllAPI.cs
    namespace WebLll.ApiPayment.BusinessObject
    {
        public class clsWebLllAPI : clsBaseApi
        {
            public void Initialize(api_rule_setup obj)
            {
                 List<Data.GetPaymentRslt> mylist=clsuser.brIlstTxn;
            }
    
        }
    }

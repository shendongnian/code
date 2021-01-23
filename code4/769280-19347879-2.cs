Should you wish to do this with a Web API controller the following model binder will help (implmenting System.Web.Http.ModelBinding.IModelBinder:
    public class SagePayTransactionNotificationModelBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            var model = actionContext.Request.Content.ReadAsStringAsync()
                            .ContinueWith(t =>
                                {
                                    var formCollection = HttpUtility.ParseQueryString(t.Result);
    
                                    return new SagePayTransactionNotification
                                    {
                                        VPSProtocol = formCollection["VPSProtocol"],
                                        TxType = formCollection["TxType"],
                                        VendorTxCode = formCollection["VendorTxCode"],
                                        VPSTxId = formCollection["VPSTxId"],
                                        Status = formCollection["Status"],
                                        StatusDetail = formCollection["StatusDetail"],
                                        TxAuthNo = formCollection["TxAuthNo"],
                                        AVSCV2 = formCollection["AVSCV2"],
                                        AddressResult = formCollection["AddressResult"],
                                        PostcodeResult = formCollection["PostcodeResult"],
                                        CV2Result = formCollection["CV2Result"],
                                        GiftAid = formCollection["GiftAid"],
                                        ThreeDSecureStatus = formCollection["3DSecureStatus"],
                                        CAVV = formCollection["CAVV"],
                                        CardType = formCollection["CardType"],
                                        Last4Digits = formCollection["Last4Digits"],
                                        VPSSignature = formCollection["VPSSignature"]
                                    };
                                })
                            .Result;
    
            bindingContext.Model = model;
    
            return true;
        }
    }

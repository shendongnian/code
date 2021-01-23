    using System;
    using System.Net;
    using eBay.Service.Core.Soap;
    namespace eBay.Service.Core.Sdk {
    	/// <summary>
    	/// Enhanced eBayAPIInterfaceService with GZIP compression support.
    	/// </summary>
    	[System.Web.Services.WebServiceBindingAttribute(Name = "eBayAPISoapBinding", Namespace = "urn:ebay:apis:eBLBaseComponents")]
        internal class eBayAPIInterfaceService2 : eBayAPIInterfaceService {
            ...
        }
    }

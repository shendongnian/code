    public class MobileOrdersController : ApiController {
        private static readonly MobileOrdersService _svc = new MobileOrdersService();
        private static readonly IContentNegotiator _conneg = GlobalConfiguration.Configuration.Services.GetContentNegotiator();
        private static readonly IEnumerable<JsonMediaTypeFormatter> _mediaTypeFormatters = new[] {
    		new JsonMediaTypeFormatter {
        		SerializerSettings = new JsonSerializerSettings {
        			ContractResolver = new DefaultContractResolver()
        		}
    		}
    	};
    
        [Authorize][HttpGet]
        public IHttpActionResult GetCustomerMobileOrders(int id, int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = "") {
            try {
            	List<MobileOrderModel> orders = _svc.GetMobileOrders(id);
            	var dto = new JTableDtoMobileOrdersImpl(orders, jtStartIndex, jtPageSize) {
            		Message = string.Format("DataSource:{0}", _svc.DataSource)
            	};
            	return new OkNegotiatedContentResult<JTableDtoMobileOrdersImpl>(dto, _conneg, Request, _mediaTypeFormatters);
            } catch (Exception ex) {
            	return new ExceptionResult(ex, this);
            }
        }
    }

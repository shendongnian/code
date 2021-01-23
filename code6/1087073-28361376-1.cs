	public class InvoiceController : CommonApiController
	{
		public async Task<IHttpActionResult> Post([FromBody]Invoice invoice)
		{
			if(User.IsInRole("Readonly"))
			{
				return Forbidden();
			}
			// Rest of code
		}
	}

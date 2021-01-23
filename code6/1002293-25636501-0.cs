   	[TestFixture]
	public class When_serializing_Order
	{
		[SetUp]
		public void SetUp()
		{
			JsonConvert.DefaultSettings = () => new JsonSerializerSettings()
			{
				ContractResolver = new CamelCasePropertyNamesContractResolver(),
				NullValueHandling = NullValueHandling.Ignore
			};
		}
		[TestCase(123, 456, 789.01, "{\"accountUri\":\"/account/123\",\"productUri\":\"/product/456\",\"total\":789.01}")]
		[TestCase(null, 456, 789.01, "{\"productUri\":\"/product/456\",\"total\":789.01}")]
		public void Should_render_exact_json(int? accountId, int productId, decimal total, string expectedJson)
		{
			var order = new Order
			{
				AccountID = accountId,
				ProductID = productId,
				Total = total
			};
			string jsonOrder = JsonConvert.SerializeObject(new OrderAdapter(order));
			Assert.That(jsonOrder, Is.EqualTo(expectedJson));
		}
	}
	public class Order
	{
		public int? AccountID { get; set; }
		public int ProductID { get; set; }
		public decimal Total { get; set; }
	}
	public class OrderAdapter
	{
		private readonly Uri _accountUri;
		private readonly Uri _productUri;
		private readonly decimal _total;
		public OrderAdapter(Order order)
		{
			_accountUri = order.AccountID != null ? CreateRelativeUri("account", order.AccountID.Value) : null;
			_productUri = CreateRelativeUri("product", order.ProductID);
			_total = order.Total;
		}
		public Uri AccountUri { get { return _accountUri; } }
		public Uri ProductUri { get { return _productUri; } }
		public decimal Total { get { return _total; } }
		private Uri CreateRelativeUri(string resourceType, int id)
		{
			return new Uri(String.Format("/{0}/{1}", resourceType, id), UriKind.Relative);
		}
	}

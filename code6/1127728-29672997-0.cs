	public class AddPaymentcard
	{
	   public string CardTypeName { get; set; }
		public IEnumerable<SelectListItem> CardTypeList
		{
			get { return _cardTypes.Select(x => new SelectListItem { Value = x.CardTypeName, Text = x.CardTypeName }).ToList(); }
		}
		public List<CardType> _cardTypes;
	 }

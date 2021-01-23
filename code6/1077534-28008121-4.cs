    private readonly Dictionary<CurrencyType, long> data;
	public long Platinum { get { return data[CurrencyType.Platinum]; } }
    ... properties for other currencies
    public CurrencyData(long platinum, long gold, long silver, long copper)
    {
        data = new Dictionary<CurrencyType, long>
	    {
			{ CurrencyType.Platinum, platinum },
			{ CurrencyType.Gold, gold },
			{ CurrencyType.Silver, silver },
			{ CurrencyType.Copper, copper }
		};
    }

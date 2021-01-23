    [ElementTag("h1")]
	public class HeaderLevel1 : ElementContainer<HeaderLevel1>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Div"/> class.
		/// Mainly used by WatiN internally.
		/// </summary>
		/// <param name="domContainer">The DOM container.</param>
		/// <param name="htmlH1Element">The HTML h1 element.</param>
		public HeaderLevel1(DomContainer domContainer, INativeElement htmlH1Element) : base(domContainer, htmlH1Element) { }
		/// <summary>
		/// Initializes a new instance of the <see cref="Div"/> class.
		/// Mainly used by WatiN internally.
		/// </summary>
		/// <param name="domContainer">The DOM container.</param>
		/// <param name="finder">The HTML h1 element.</param>
		public HeaderLevel1(DomContainer domContainer, ElementFinder finder) : base(domContainer, finder) { }
		/// <summary>
		/// Gets the name of this Watin element.
		/// </summary>
		/// <returns></returns>
		public string GetName()
		{
			return "HeaderLevel1";
		}
	}    

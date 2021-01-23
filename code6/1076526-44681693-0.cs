	public class MovieLibrary
	{
		string[] _availableGenres = { "Comedy", "Drama", "Romance" };
		public MovieLibrary()
		{
		}
		public string[] AvailableGenres
		{
			get
			{
				return _availableGenres;
			}
		}
	}
	<asp:LinqDataSource 
		ContextTypeName="MovieLibrary" 
		TableName="AvailableGenres" 
		ID="LinqDataSource1" 
		runat="server">
	</asp:LinqDataSource>
	<asp:DropDownList 
		DataSourceID="LinqDataSource1"
		runat="server" 
		ID="DropDownList1">
	</asp:DropDownList>

	public class  ArticleForSale
	{
		public string Name{get; set;}
		public decimal Price{get;set;}
		
		public override string ToString()
		{
			return Name +"\t=\t" + Price;
		}
	}
	List<ArticleForSale> articleForSale = new List<ArticleForSale>{
		new ArticleForSale{ Name= "schoen", Price=89.80m },
		new ArticleForSale{ Name= "muts", Price= 17.99m},
		new ArticleForSale{ Name= "sjaal", Price=89.80m },
		new ArticleForSale{ Name= "rok", Price= 10.00m },
		new ArticleForSale{ Name= "jurk", Price=45.00m },
		new ArticleForSale{ Name= "Gouden Horloge", Price=780.00m },
		new ArticleForSale{ Name= "Gouden Ketting", Price=7800.00m},
		new ArticleForSale{ Name=  "Handschoenen", Price=1000m},
		new ArticleForSale{ Name= "Sokken", Price=89.80m },
		new ArticleForSale{ Name= "Beenwarmers", Price=89.80m },
	};
	
	foreach(var art in articleForSale)
	{
		Console.WriteLine(art);
	}
	
	for(int i = 0; i < articleForSale.Count(); i++)
	{
		Console.WriteLine(articleForSale[i]);
	}

	public class Category
	{
		public int CategoryID;
		public List<Category> Subcategories = new List<Category>();
		public int UniqueSubcategoriesCount
		{
			get
			{
				return this.GetUniqueSubcategories().Count();
			}
		}
		
		private IEnumerable<Category> GetUniqueSubcategories()
		{
			return
				this
					.GetSubcategories()
					.ToLookup(x => x.CategoryID)
					.SelectMany(xs => xs.Take(1));
		}
		
		private IEnumerable<Category> GetSubcategories()
		{
			return this.Subcategories
				.Concat(this.Subcategories
					.SelectMany(x => x.GetSubcategories()));
		}
	}

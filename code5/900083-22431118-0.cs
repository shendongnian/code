    public class ChooseCategoryViewModel : ViewModelBase
    {
		private string[] _categories =
			{ "Fruit", "Meat", "Vegetable", "Cereal" };
		public string[] Categories
		{
			get { return _categories; }
		}
		
		private string _selectedCategory;
		public string SelectedCategory
		{
			get { return _selectedCategory; }
			set
			{
				_selectedCategory = value;
				OnPropertyChanged("SelectedCategory");
			}
		}
		
		private string _categoryName;
		public string CategoryName
		{
			get { return _categoryName; }
			set
			{
				_categoryName = value;
				OnPropertyChanged("CategoryName");
				if (Categories.Contains(value))
				{
					SelectedCategory = value;
				}
				else
				{
					SelectedCategory = null;
				}
			}
		}
	}

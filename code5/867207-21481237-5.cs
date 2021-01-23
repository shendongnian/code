		[WebMethod]
		public static List<SelectItem> GetSubCategories(string Id)
		{
            // Returning dummy data for demo purposes
			var subCats = new List<SelectItem>();
			if (Id == "1")
			{
				subCats.Add(new SelectItem { Id = "1", Text = "1 Subs"});
			}
			else if (Id == "2")
			{
				subCats.Add(new SelectItem { Id = "2", Text = "2 Subs"});
			}
		
			return subCats;
		}

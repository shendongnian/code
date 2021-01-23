    public static IList<SelectListItem> ToDropDownList(this IEnumerable<Category> query)
    {
    	List<SelectListItem> listItems = new List<SelectListItem>();	
    	foreach (var cat in query)
    	{
    	  var texts = cat.CategoryTexts.Where(w=>w.Language.Format == (string)Session["chosen_language"]).FirstOrDefault();
    	  listItems.Add(new SelectListItem
    	  {
    		Text = texts == null ? cat.Id.ToString() : texts.Name,
    		Value = cat.Id.ToString(),
    	  });
    	}
    }

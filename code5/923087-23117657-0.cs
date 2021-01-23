    public class SelectListValue{
      public string Text {get;set;}
      public string Value {get;set;}
    }
    public ActionResult SomeActionMethod()
    {
      var categories = GetCategories() //Get your list of categories
      var selectListItems = new List<SelectListValue>();
      foreach(var item in categories)
      {
        var text = GetCategoryDisplay() //You will need to figure out how to generate the text, like Components > Web Cameras. This doesn't need to be a method. It could be a property on the Category object.
        selectListItems.Add(new SelectListValue {Text = text, Value = item.CategoryId.ToString()});
      }
      ViewData["CategoryList"] = new SelectList(selectListItems, "Value", "Text");
    }

    public class ProductCategoryViewModel
    {
        public string Image{get;set;}
        public string Name{get;set;}
        public string Description{get;set;}
        public double Price{get;set;}
        
        public IEnumerable<Category> Categories{get;set;}
        public ()
        {
            Categories = Categories.GetAll().ToList();
        }
    }
    @foreach (var item in Model.Categories) {
        <input type="checked" name="Categories" value="@(item.Name)">@(item.Name)
        //or use html helper which will add hidden input as well
        // @Html.CheckboxFor(x=> x.Name);
    }

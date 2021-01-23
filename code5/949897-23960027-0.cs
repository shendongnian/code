    public class ProductViewModel
    {
       ...
        public IEnumerable<CategoryViewModel> CategoryViewModel { get; set; }
    }
     CategoryViewModel = product.Categories.Select(c=>new CategoryViewModel
                                {
                                    ...
                                })

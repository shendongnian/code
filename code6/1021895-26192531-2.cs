    public class ProductController : Controller
    {
        public ViewResult Edit(int productID)
        {
            ProductEditViewModel model = new ProductEditViewModel
            {
                Product = this._repository.Products.Where(m => m.ProductID == productID).FirstOrDefault()
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(int productId)
        {
            ProductEditViewModel model = new ProductEditViewModel
            {
                Product = _repository.Products.First(m => m.ProductID == productId)
            };
            TryUpdateModel(model);
            if (ModelState.IsValid)
            {
                _repository.Save(model.Product);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
        public ViewResult Create()
        {
            return View("Edit", new Product());
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            return Edit(product.ProductID);
         }
     }

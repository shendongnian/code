    public class Productscontroller {
    public ActionResult Read([DataSourceRequest]DataSourceRequest request)
            {
            var products = proxy.GetProducts();
            DataSourceResult result = products.ToDataSourceResult(request, ProductsModel => new ProductsModel()
            {
                id = products.id,
                ItemName= products.ItemName,
                Qty= products.Qty,
                Price = products.Price,
                total = products.Qty * products.Price
            });
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    public ActionResult Update([DataSourceRequest]DataSourceRequest request, ProductsModel product)
            {
            var products = proxy.GetProductById(product.Id);
            Proxy<Products>.Update(products);
        }
    }

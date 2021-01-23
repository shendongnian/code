    public class HomeController : Controller {
        private async Task<string> Delete(string displayName) {
            Thread.Sleep(1000);
            return string.Format("{0} has been deleted", displayName);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<JsonResult> DeleteItem(string displayName, int product) {
            Task<string> deleteTask = Delete(displayName);
            return new JsonResult() {
                Data = new { 
                    product = product,
                    result = await deleteTask }
            };
        }
        public ActionResult Index() {
            AdministratorViewModel model = new AdministratorViewModel() {
                Uploads = new List<ItemModel>() {
                    new ItemModel() {
                        DisplayName = "First one",
                        Product = 1,
                        ReleaseDate = DateTime.Now,
                        Size = 11
                    },
                    new ItemModel() {
                        DisplayName = "Second one",
                        Product = 2,
                        ReleaseDate = DateTime.Now.AddDays(1),
                        Size = 12
                    }
                }
            };
            return View(model);
        }
    }

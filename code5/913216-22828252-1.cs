        public class DocProductController : Controller
        {
            private IDocProductRepository repository;
            private IDocMainRepository repositoryMain;
        
            public DocProductController(IDocProductRepository docProductRepository,
                  IDocMainRepository docMainRepository)
            {
                this.repository = docProductRepository;
                this.repositoryMain = docMainRepository;
            }
        
        
            public ActionResult DocProductList()
            {
                var model = new DocProductViewModel(repository);
        
                               //link tables(entities) part will be in the repository functions
                               //from docProduct in repository.DocProduct
                               //join docMain in repositoryMain.DocMain
                               //on docProduct.Doc_Id equals docMain.Doc_Id
                               //select new { DocMainTitle = docMain.Doc_Title,
                               //DocProductContent = docProduct.DocProduct_Content };
           
                   
                return View(model);
            }
        }

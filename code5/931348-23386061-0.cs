    Root    
    - Controllers 
               - CommonController 
                    namespace Nop.Web.Controllers
                    {
                      public class CommonController
                      {
                        ....
                       }
                   }
    - Areas (book)
            - Controllers
                        - CustomerController
                            namespace Nop.Web.Areas.Book.Controllers
                            {
                              public class CustomerController : CommonController
                              {
                                  public ActionResult LoginBox(...)
                                 {..}
                              }
                            }
            - View
                      - Customer
                              - LoginBox.cshtml

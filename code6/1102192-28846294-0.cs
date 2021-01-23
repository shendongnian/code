    public class FooController
    {
         public ActionResult Edit()
         {
              var viewModel = new FooViewModel
              { 
                  Bars = new List<BarViewModel> { new BarViewModel() } 
              };
              return View(viewModel);
         }
    
         // For remote validation
         public ActionResult CheckName([Bind(Prefix = "Bars[0].Name")] string name)
         {
              // Perform remote validation
         }
    }

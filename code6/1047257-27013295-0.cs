    public class FooController : Controller
    {
        public async Task<ActionResult> AddBookingCreditCard()
        {
            TempData["ccInfo"] = "Hell world";
            return RedirectToAction("Book", new { id = 1, travellers = 2 });
        }
    
        [HttpGet]
        public async Task<ActionResult> Book(int id, int travellers)
        {
            var vm = new object();
    
            if (TempData["ccInfo"] != null)
            {
                vm = new object();
            }
    
            // lot of code
            return new EmptyResult();
        }
    }

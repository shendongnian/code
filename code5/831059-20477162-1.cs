    public class YourController : Controller {
    
        // Include an action here to display your view
    
        [HttpPost]
        public ActionResult Submit(YourModel model) {
            var csvData = model.Table.ToCsv(); // assuming you have this method already since it's in your code above
            // Do something with the data and return a view
        }
    }

    public class FooController : Controller
    {
        public ActionResult Create()
        {
            IRandomValueGenerator generator = RandomValueGeneratorFactory.GetGenerator();
            int value = generator.GenerateRandomValue();
            // Do other stuff
            return View(...);
        }
    }

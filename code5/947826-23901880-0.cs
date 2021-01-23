    public class HomeController
    {
        private IFoo _foo = null;
        // Your code as usual
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if(disposing && _foo != null)
                _foo.Dispose();
        } 
    }

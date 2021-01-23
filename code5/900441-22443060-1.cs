    public ActionResult Index() {
        // No need to go higher, as it's always just as random with a modulo
        int rnd = (new Random()).Next(5); 
        try {
            switch (rnd) {
                case 1: // Or any of the 5 numbers you want.
                    throw new ArgumentException();
                case 4: // Again, any of the 5 numbers
                    throw new MyApplicationException();
                default:
                    return RedirectToAction("Index");
            }
        }
        catch (Exception ex) {
            // Do your error logging here.
        }
    }

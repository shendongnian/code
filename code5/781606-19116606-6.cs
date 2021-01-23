    public ActionResult Foo()
    {
        var list = new List<AbstractBase>()
        {
            new Derived1{ A = 1, B = 2, C = 3},
            new Derived2{ A = 1, D = 4},
        };
        return View(list);
    }

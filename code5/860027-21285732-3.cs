    public ActionResult Execute()
    {
        using (var service = new MyService())
        {
            service.CallA();
            service.CallB();
        }
    }

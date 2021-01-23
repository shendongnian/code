    public PartialViewResult YourPartialView(int parameter)
    {
        // get your viewmodel using the parameter...
        var vm = new YourPartialViewModel(parameter);
        return PartialView(vm);
    }

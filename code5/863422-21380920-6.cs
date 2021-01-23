    // inside "xxxxxx.Designer.cs"
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (_filter != null)
                _filter.Dispose();
            // this part is added by Visual Studio designer
            if (components != null)
                components.Dispose();
        }
     
        base.Dispose(disposing);
    }

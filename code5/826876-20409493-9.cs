    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            IDisposable d = _repository as IDisposable;
            if (d != null)
                d.Dispose();
            GC.SupressFinalize(this);
        }
        base.Dispose(disposing);
    }

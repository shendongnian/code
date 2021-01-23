    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _child1.Dispose();
            _child2.Dispose();
        }
    }

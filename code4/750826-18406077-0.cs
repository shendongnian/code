    protected void Page_Unload(Object sender, EventArgs e)
    {
        if (_context != null)
        {
            if (_context.Context.Connection.State == ConnectionState.Open)
                _context.Context.Connection.Close();
            _context.Context.Dispose();
            _context.Context = null;
            _context = null;
        }
    }

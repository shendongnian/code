    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (components != null))
        {
          components.Dispose();
        }
         someResource.Dipose(); //  <-----
        // HERE DISPOSE OTHER STUFF
      }
    
      base.Dispose(disposing);
    }

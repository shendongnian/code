    protected void Application_EndRequest() {
        if (Context.AllErrors != null) {
            System.Diagnostics.Debugger.Break();
            foreach (var ex in Context.AllErrors) {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    } 
 

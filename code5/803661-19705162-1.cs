    private void HandleError(Exception ex) {
        var st = new StackTrace ();
        var sf = st.GetFrame (1); // get the previous method that called this
                                  // (not this method)
        var previousMethod = sf.GetMethod ();
        var errorMessage = string.Format("Error in method {0} with Exception {1}", 
                               previousMethod.Name,
                               ex.Message);
    }

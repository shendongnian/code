    private static void HandleError(Exception ex) {
        StackTrace st = new StackTrace ();
        StackFrame sf = st.GetFrame (1); // get the previous method that called this
                                         // (not this method)
        MethodBase previousMethod = sf.GetMethod ();
        var errorMessage = string.Format("Error in method {0} with Exception {1}", 
                               previousMethod.Name,
                               ex.Message);
    }

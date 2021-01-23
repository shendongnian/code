    // you'd want to add this check early in the method body
    if(!p_enclosure.HasValue || p_transaction == null || !p_operation.HasValue ...
    {
        try{
           // log the error
        }catch{
           // ignore errors from the logging system
        }
   
        //   and stop processing
        return null; // or whatever makes sense in case of invalid arguments
    }

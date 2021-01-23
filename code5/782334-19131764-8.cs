    try {
        Response.Clear();
        // ...
    } catch (Exception ex) {
        //log error
    }
    // use HttpContext.Current.ApplicationInstance.CompleteRequest(); instead  
    Response.End();  

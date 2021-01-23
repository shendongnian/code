    {
        ...
        context.Response.End(); //always throws an exception
    }
    catch (ThreadAbortException e)
    {
        //this is special for the Response.end exception
    }
    catch (Exception e)
    {
         context.Response.ContentType = "text/plain";
         context.Response.Write(e.Message);
    }

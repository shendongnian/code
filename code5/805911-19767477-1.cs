    catch (Exception ex)
    {
        ctx.StatusCode = System.Net.HttpStatusCode.InternalServerError;
        ctx.SuppressEntityBody = true;
        System.Diagnostics.Trace.WriteLine(ex.Message, "GetAllUsers"); // log exception
    }

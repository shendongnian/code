    // find section based on ID
    // ... actual code ...
    if (section != null)
    {
        // process data and assign to model
        return View(model);
    }
    else
    {
        Response.StatusCode = (int) System.Net.HttpStatusCode.NotFound;
        return View("NoSectionFound");
    }

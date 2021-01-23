    catch (Exception ex)
    {
        var wex = GetNestedException<WebException>(ex);
        // If there is no nested WebException, re-throw the exception.
        if (wex == null) { throw; }
        // Get the response object.
        var response = wex.Response as HttpWebResponse;
        // If it's not an HTTP response or is not error 403, re-throw.
        if (response == null || response.StatusCode != HttpStatusCode.Forbidden) {
            throw;
        }
        // The error is 403.  Handle it here.
    }

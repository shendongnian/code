    catch (Exception ex)
    {
        var wex = (ex as WebException) ?? (ex.InnerException as WebException);
        if (wex == null) { throw; }
        var response = wex.Response as HttpWebResponse;
        if (response == null && response.StatusCode != HttpStatusCode.Forbidden) {
            throw;
        }
        // Handle 403 case here.
    }

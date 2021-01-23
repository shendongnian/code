    /// <summary>
    /// Retrieve the metadata from the endpoint.
    /// </summary>
    private void RetrieveMetadata() {
        metadataLock.EnterWriteLock();
        try {
            // retrieve the metadata
            OpenIdConnectConfiguration config = Task.Run(configManager.GetConfigurationAsync).Result;
            // and update
            issuer = config.Issuer;
            securityTokens = config.SigningTokens;
        } catch (Exception ex) when (CheckHttp404(ex)) {
            // ignore 404 errors as they indicate that the policy does not exist for a tenant
            logger.Warn($"Policy endpoint not found for {metadataEndpoint} - ignored");
            throw ex;
        } catch (Exception ex) {
            logger.Fatal(ex, $"System error in retrieving token metadatafor {metadataEndpoint}");
            throw ex;
        } finally {
            metadataLock.ExitWriteLock();
        }
    }
    /// <summary>
    /// Check if the inner most exception is a HTTP response with status code of Not Found.
    /// </summary>
    /// <param name="ex">The exception being examined for a 404 status code</param>
    /// <returns></returns>
    private bool CheckHttp404(Exception ex) {
        // get the inner most exception
        while(ex.InnerException != null) {
            ex = ex.InnerException;
        }
        // check if a HttpWebResponse with a 404
        return (ex is WebException webex) && (webex.Response is HttpWebResponse response) && (response.StatusCode == HttpStatusCode.NotFound);
    }

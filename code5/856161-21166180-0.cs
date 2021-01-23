    Friend Shared Function GetRequestTokenQuery() As OAuthWebQuery
        Dim oauth = New OAuthWorkflow() With { _
            .ConsumerKey = AppSettings.consumerKey, _
            .ConsumerSecret = AppSettings.consumerKeySecret, _
            .SignatureMethod = OAuthSignatureMethod.HmacSha1, _
            .ParameterHandling = OAuthParameterHandling.HttpAuthorizationHeader, _
            .RequestTokenUrl = AppSettings.RequestTokenUri, _
            .Version = AppSettings.oAuthVersion, _
            .CallbackUrl = AppSettings.CallbackUri _
        }
    
            Dim info = oauth.BuildRequestTokenInfo(WebMethod.[Get])
            Dim objOAuthWebQuery = New OAuthWebQuery(info, False)
            objOAuthWebQuery.HasElevatedPermissions = True
            objOAuthWebQuery.SilverlightUserAgentHeader = "Hammock"
            Return objOAuthWebQuery
        End Function

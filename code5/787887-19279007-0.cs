        public override void OnAuthenticated ( IServiceBase authService,
                                               IAuthSession session,
                                               IOAuthTokens tokens,
                                               Dictionary<string, string> authInfo )
        {
            // truncated for brevity
            //Important: You need to save the session!s
            authService.SaveSession( session, SessionExpiry );
            // THIS ENSURES THE SESSION IS ACCESSABLE BY THE APP 
            base.OnAuthenticated(authService, session, tokens, authInfo);
        }

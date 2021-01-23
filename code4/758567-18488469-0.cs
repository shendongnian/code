    public OAuthTokenMappings()
        {
            CompositeId()
                .KeyReference(c => c.Provider, "Provider")
                .KeyReference(c => c.ProviderUserId, "ProviderUserId");
            Map(c => c.Token);
            Map(c => c.User); //This is most likely the culprit. Should be a References or HasOne mapping
            Map(c => c.Secret);
        }

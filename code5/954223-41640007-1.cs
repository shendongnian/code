    public override Task<bool> IsEmailConfirmedAsync(string userId)
    {
      var profile = UserProfileType.FetchUserProfile(AtlasBusinessObject.ClientId.ToString(), decimal.Parse(userId));
      Task.FromResult(profile.EmailAddress.NullIfEmpty() != null);
    }

    public override async Task<bool> IsEmailConfirmedAsync(string userId)
    {
      await Task.Delay(0);
      var profile = UserProfileType.FetchUserProfile(AtlasBusinessObject.ClientId.ToString(), decimal.Parse(userId));
      return profile.EmailAddress.NullIfEmpty() != null;
    }

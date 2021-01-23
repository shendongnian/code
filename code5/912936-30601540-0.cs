    private static Task OnGoogleAuthenticated(GoogleAuthenticatedContext context)
    {
        var identity = ((ClaimsIdentity)context.Principal.Identity);
        var pictureUrl = context.User["image"].Value<string>("url");
        // Pass the picture url as a claim to be used later in the application
        identity.AddClaim(new Claim(ClaimTypes.PictureUrl, pictureUrl));
        return Task.FromResult(0);
    }

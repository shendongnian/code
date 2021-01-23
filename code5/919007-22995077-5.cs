    public HttpResponseMessage ChangePassword(
        [FromBody]ChangePasswordModel model
    )
    {
        Task.WhenAll(SendChangePasswordEmailAsync(model.userId, model.email));
        return TheResponse
            .CreateSuccessResponse(Constants.PasswordHasBeenSuccessfullyChanged);
    }

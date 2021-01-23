    public HttpResponseMessage ChangePassword(
        [FromBody]ChangePasswordModel model
    )
    {
        SendChangePasswordEmailAsync(model.userId, model.email).Wait();
        return TheResponse
            .CreateSuccessResponse(Constants.PasswordHasBeenSuccessfullyChanged);
    }

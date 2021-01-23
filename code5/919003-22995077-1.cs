    public async Task<HttpResponseMessage> ChangePassword(
        [FromBody]ChangePasswordModel model
    )
    {
        await SendChangePasswordEmailAsync(model.userId, model.email);
        return TheResponse
            .CreateSuccessResponse(Constants.PasswordHasBeenSuccessfullyChanged);
    }

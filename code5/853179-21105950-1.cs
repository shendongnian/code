    public ResetPasswordResponse ResetPassword(ResetPasswordRequest resetPasswordRequest)
        {
            return SafeMethodCall<ResetPasswordRequest, ResetPasswordResponse>
                ((ResetPasswordRequest request,
                    ResetPasswordResponse response, out string signInIdentifier) =>
            {
                signInIdentifier = null;
                if (!_validator.ValidateModel(request, response))
                    return response;
                var signIn =
                    _manager.GetSignInByPasswordResetToken(request.PasswordResetToken);
                if (signIn != null)
                {
                    signInIdentifier = signIn.SignInIdentifier.ToString();              
                }
                var result = _manager.ResetPassword(request.SiteIdentifier,
                request.PasswordResetToken, request.Password);
                if (!result)
                {
                    AddServiceError(response, "The password could not be reset",
                        ErrorType.GeneralError);
                }
                return response;
            }, resetPasswordRequest);
        }

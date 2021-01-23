    userBusinessListingViewModel.BusinessCredentialsViewModels
        = userCredential.BusinessCredentials.Select(
            x => new BusinessCredentialsViewModel
                {
                    Id = x.Id,
                    /* etc, etc */
                });

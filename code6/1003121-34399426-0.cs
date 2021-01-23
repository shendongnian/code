        /// <summary>
        /// Creates a new user account.
        /// </summary>
        /// <param name="model">Object containing the basic information about the user.</param>
        /// <returns>User with the basic data and the JWT token.</returns>
        /// <exception cref="BusinessLogicException">
        /// Throws business exception if the user that is being created contains invalid data, such as invalid email, username and so on.
        /// </exception>
        public async Task<ResponseMessage<UserLogin>> Post(PostUserModel model)
        {
            ...
        }

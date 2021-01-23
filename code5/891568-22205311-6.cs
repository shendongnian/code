        public Task UpdateAsync(IdentityUser user)
        {
            // here an exception will be thrown if there is a concurrency issue
            byte[] timestamp = Convert.FromBase64String(user.UserModel.Timestamp);
            AdminUserEntityManagement.UpdateCompleteAdminUserEntity(userEntity, timestamp);
            return Task.FromResult<object>(null);
        }

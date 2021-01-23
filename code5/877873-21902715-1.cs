       public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await base.GetCacheOrExecute("users", doGetAllUsersAsync); //
        }
        private async Task<IEnumerable<User>> doGetAllUsersAsync() {
           //more code...
        }

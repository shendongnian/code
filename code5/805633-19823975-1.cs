    public Task<DbUser> LoginAsync(string login, string password)
            {
                return Task.Run<DbUser>( () => Login(login, password));
            }
    
    private DbUser Login(string login, string password)
            {
                try
                {
                    string hashedPassword = PasswordHasher.Hash(password);
                    var user = _dbContext.Users.FirstOrDefaultAsync(x => x.UserName == login);
                    if (user.Result != null && user.Result.Password == hashedPassword)
                        return user.Result;
                    return null;
                }
                catch(Exception ex)
                {
                    _logger.Error("Blad logowania uzytkownika", ex);
                    return null;
                }
            }

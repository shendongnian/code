    var logins = ctx.Users.Select(user => new FlatUserModel
                                        {
                                            Id = user.Id,
                                            Name = user.UserName,
                                            Email = user.Email
                                        })
                                        .ToArray();
    return logins;

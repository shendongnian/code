    foreach (var user in userList.Where(x => x.ContactInformation != null && x.Role1 != null))
            {
                    users.Add(new UserGridModel()
                    {
                        ID = user.ID,
                        Username = user.Username,
                        EMail = user.ContactInformation.EMail,
                        Surname = user.ContactInformation.Surname,
                        Role = user.Role1.Description
                    });
              }

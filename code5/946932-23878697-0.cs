            List<User> users = JsonConvert.DeserializeObject<List<User>>(rawData);
            foreach (User user in users)
            {
                Console.WriteLine(user.UserName);
                foreach (Role role in user.UserRoles)
                {
                    Console.WriteLine(role.RoleName);
                }
            }

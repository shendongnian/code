               //Iterate over all users in list and verify they are in the everyone group
                foreach (User myUser in myUsers)
                {
                    User tempUser = myUser;
                    bool tempRes = false;
                    client.IsUserInGroup(tempUser.ID, 0,
                        (result) =>
                        {
                            tempRes = result;
                        });
                    if (tempRes)
                    {
                        Console.WriteLine(String.Format("{0} is in Everyone Group and Public Area", tempUser.Name));
                    }
                    System.Threading.Thread.Sleep(75);  //Not a good way of enforcing sync!
                }

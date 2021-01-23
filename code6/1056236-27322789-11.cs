    /// <summary>
    /// This populates the Db with 10 users. All users
    /// from 1 to 9 are being followed by user 0
    /// </summary>
    public static void PopulateDb()
    {
        // Create the logged in user
        var loggedInUser = new User { Id = 0, Posts = new List<Post>() };
        db.Users.Add(loggedInUser);
        // Create 9 other users with 4 posts each
        for (int i = 1; i < 10; i++)
        {
            var newUser = new User
            {
                Id = i,
                Posts =
                    new List<Post>
                    {
                        new Post {Text = "Post #" + i},
                        new Post {Text = "Post #" + (i * 10)},
                        new Post {Text = "Post #" + (i * 20)},
                        new Post {Text = "Post #" + (i * 30)}
                    }
            };
            // Add the other user
            db.Users.Add(newUser);
            // Have the logged in user follow this new user
            db.Follow.Add(new Follow { loggedInUser = loggedInUser, 
                userToFollow = newUser });
        }
    }

    using (var cluster = new Cluster())
            {
                using (var bucket = cluster.OpenBucket("test"))
                {
                    var users = from c in bucket.Queryable<User>()
                                where c.Age==25
                                select c;
                    foreach (var user in users)
                    {
                        Console.WriteLine("\tName={0}, Age={1}, Email={2}",
                            user.FirstName,
                            user.Age,
                            user.Email
                            );
                    }
                }
            }

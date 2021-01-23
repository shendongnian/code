    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    public class Entity
    {
        public Entity()
        {
            _users = new List<User>();
        }
        public string Type { get; set; }
        public List<User> _users;
        public List<User> Users
        {
            get
            {
                //You can add your rules for users here 
                return _users;
            }
        }
        public User AssignedUser { get; set; }
    }
    public class User
    {
        public User()
        {
            Entities = new Dictionary<string, Entity>();
        }
        public string userId { get; set; }
        public Dictionary<string, Entity> Entities { get; set; }
        public int TotalEntities { get; set; }
        public bool Ignored { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Load Entities, you can change the number of entities generated here
            int numEntityToGenerate = 50001;
            //Create users
            var userList = new List<User> {
                                new User { userId = "U0" } ,
                                new User { userId = "U1" } ,
                                new User { userId = "U2" } ,
                                new User { userId = "U3" } ,
                                new User { userId = "U4" } 
                            };
            userList = userList.OrderBy(u => u.userId).ToList();
            var entities = GenerateEntities(userList, numEntityToGenerate);
            foreach (var entity in entities)
            {
                foreach (var user in entity.Users)
                {
                    user.Entities.Add(entity.Type, null);
                }
            }
            foreach (var entity in entities)
            {
                Console.Write(".");
                var user = entity.Users.OrderBy(u => u.TotalEntities).First();
                if (!user.Entities.ContainsKey(entity.Type))
                    user.Entities.Add(entity.Type, null);
                user.Entities[entity.Type] = entity;
                user.TotalEntities++;
                entity.AssignedUser = user;
            }
            var averagePerUser = 0;
            var busyUsers = userList.Count(a => a.TotalEntities != 0);
            //Calculate the expected average per user 
            var totalEntities = entities.Count;
            averagePerUser = (totalEntities) / (busyUsers);
            Console.WriteLine();
            Console.WriteLine("Total Entities: " + totalEntities);
            Console.WriteLine("Average Entities: " + averagePerUser);
            Console.WriteLine("Busy Users: " + busyUsers);
            Console.WriteLine();
            List<int> oldDifference = null;
            List<int> newDifference = null;
            do
            {
                oldDifference = GetDifferenceList(userList, averagePerUser);
                OutputAllocation(userList, averagePerUser);
                var orderedUserList = userList.OrderByDescending(u => u.TotalEntities).ToList();
                //Loop through the users and compare to the remaining users
                for (var i = 0; i < orderedUserList.Count - 1; i++)
                {
                    for (var j = i + 1; j < userList.Count; j++)
                    {
                        BalanceUsers(userList[i], userList[j], entities, averagePerUser);
                    }
                }
                newDifference = GetDifferenceList(userList, averagePerUser);
            } while (!Enumerable.SequenceEqual(oldDifference.OrderBy(t => t), newDifference.OrderBy(t => t)));
            Console.WriteLine("Total assigned: " + userList.Sum(u => u.TotalEntities));
            Console.WriteLine();
            OutputAllocation(userList, averagePerUser);
            Console.WriteLine("Total assigned: " + userList.Sum(u => u.TotalEntities));
            Console.WriteLine();
            //Check data quality
            foreach (var entity in entities)
            {
                //Check to see if assigned user is valid
                Debug.Assert(entity.Users.Contains(entity.AssignedUser));
            }
            Console.ReadLine();
        }
        private static List<int> GetDifferenceList(List<User> userList, int averagePerUser)
        {
            var differences = new List<int>();
            foreach (var user in userList)
            {
                var difference = user.TotalEntities - averagePerUser;
                if (user.TotalEntities != 0)
                    differences.Add(difference);
            }
            return differences;
       
        }
        private static void OutputAllocation(List<User> userList, int averagePerUser)
        {
            //Display allocation after initial assignment
            foreach (var user in userList)
            {
                var difference = user.TotalEntities - averagePerUser;
                if (user.TotalEntities == 0)
                    Console.WriteLine("Assignment  " + user.userId + " has " + user.TotalEntities);
                else
                    Console.WriteLine("Assignment  " + user.userId + " has " + user.TotalEntities + " difference " + difference);
            }
            Console.WriteLine("Total assigned: " + userList.Sum(u => u.TotalEntities));
            Console.WriteLine();
        }
        /// <summary>
        /// Compares two users and balances them out
        /// </summary>
        private static void BalanceUsers(User firstUser, User secondUser, List<Entity> entities, int averagePerWorker)
        {
            //Get the difference betweent the current users and the average worker
            var firstUserDiff = firstUser.TotalEntities - averagePerWorker;
            var secondUserDiff = secondUser.TotalEntities - averagePerWorker;
            if ((firstUserDiff != 0 && secondUserDiff != 0) && Math.Abs(firstUserDiff - secondUserDiff) > 1)
            {
                //Get all the entities which the two users share
                var sharedEntity = entities.Where(x => x.Users.Contains(firstUser) && x.Users.Contains(secondUser));
                foreach (var entity in sharedEntity)
                {
                    //Find out the direction the change needs to occur
                    if (firstUserDiff >= secondUserDiff)
                    {
                        //Removing from firstUser so find out if it has the entity
                        if (firstUser.Entities[entity.Type] != null)
                        {
                            firstUser.Entities[entity.Type] = null;
                            firstUser.TotalEntities--;
                            secondUser.Entities[entity.Type] = entity;
                            secondUser.TotalEntities++;
                            entity.AssignedUser = secondUser;
                        }
                    }
                    else
                    {
                        //Removing from secondUser so find out if it has the entity
                        if (secondUser.Entities[entity.Type] != null)
                        {
                            firstUser.Entities[entity.Type] = entity;
                            firstUser.TotalEntities++;
                            secondUser.Entities[entity.Type] = null;
                            secondUser.TotalEntities--;
                            entity.AssignedUser = firstUser;
                        }
                    }
                    firstUserDiff = firstUser.TotalEntities - averagePerWorker;
                    secondUserDiff = secondUser.TotalEntities - averagePerWorker;
                    //Check to see if the two users have been balanced or if the difference is only one
                    //IF that is the case break the for loop
                    if ((firstUserDiff != 0 && secondUserDiff != 0) && (firstUserDiff == secondUserDiff) && Math.Abs(firstUserDiff - secondUserDiff) <= 1)
                        break;
                }
            }
        }
        /// <summary>
        /// Generate a list of entities randomly adding a list of potential users to each entity
        /// </summary>
        /// <param name="userList">list of available users</param>
        /// <param name="totalEntities">Total number of entities required</param>
        /// <returns>A list of entities</returns>
        private static List<Entity> GenerateEntities(List<User> userList, int totalEntities)
        {
            var entities = new List<Entity>();
            Random random = new Random();
            for (var i = 0; i < totalEntities; i++)
            {
                var entity = new Entity { Type = "E" + (i + 1).ToString() };
                entities.Add(entity);
                //This code will either an entity to the last user or to a random list of users excluding the last one
                if (random.Next(12) == 0)
                {
                    var user = userList[userList.Count() - 1];
                    entity.Users.Add(user);
                }
                else
                {
                    var numOfUsers = random.Next(2);
                    for (var j = 0; j <= numOfUsers; j++)
                    {
                        var user = userList[random.Next(userList.Count() - 1)];
                        if (!entity.Users.Contains(user))
                            entity.Users.Add(user);
                    }
                }
                //if (i <= totalEntities / 2 )
                //{
                //    entity.Users.Add(userList[0]);
                //    entity.Users.Add(userList[1]);
                //}
                //else
                //{
                //    entity.Users.Add(userList[2]);
                //    entity.Users.Add(userList[1]);
                //}
            }
            return entities;
        }
    }

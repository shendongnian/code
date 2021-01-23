    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
        public class Entity
        {
            public string Type { get; set; }
        }
        public class User
        {
            public User()
            {
                EntitiesCount = new Dictionary<string, int>();
            }
            public string userId { get; set; }
            public Dictionary<string, int> EntitiesCount { get; set; }
            public int TotalEntities { get; set; }
            public bool Ignored { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                for (var myLoop = 0; myLoop < 100; myLoop++)
                {
                    //Create users
                    var userList = new List<User> {
                        new User { userId = "U0" } ,
                        new User { userId = "U1" } ,
                        new User { userId = "U2" } ,
                        new User { userId = "U3" } ,
                        new User { userId = "U4" } 
                    };
                    userList = userList.OrderBy(u => u.userId).ToList();
                    //Assign Users to Entities
                    var entityUsers = new Dictionary<string, List<User>>() { 
                        { "E0", 
                          new List<User> { 
                              userList[0] ,
                              userList[1] 
                          } 
                        } ,
                        { "E1", 
                          new List<User> { 
                              userList[4]
                          } 
                        } ,
                        { "E2", 
                          new List<User> { 
                              userList[1],
                              userList[2],
                              userList[3] 
                          } 
                        } 
                    };
                    //var entityUsers = new Dictionary<string, List<User>>() { 
                    //        { "E0", 
                    //          new List<User> { 
                    //              userList[0] ,
                    //              userList[1] 
                    //          } 
                    //        } ,
                    //        { "E1", 
                    //          new List<User> { 
                    //              userList[1],
                    //              userList[2],
                    //          } 
                    //        } ,
                    //    };
                    //Load Entities, you can change the number of entities generated her
                    var entities = GenerateEntities(entityUsers.Count(), 50000);
                    //Group the Entities by their type and display total number
                    var lookupEntities = entities.ToLookup(e => e.Type);
                    foreach (var lookupEntity in lookupEntities)
                    {
                        Console.WriteLine(lookupEntity.Key + " has " + lookupEntity.Count());
                    }
                    // Users are ignored if there is a one to one mapping
                    var ignoreUsers = 0;
                    //Entities are ignored if they are only handled by one user
                    var ignoreEntities = 0;
                    foreach (var entityUser in entityUsers)
                    {
                        foreach (var user in entityUser.Value)
                        {
                            user.EntitiesCount.Add(entityUser.Key, 0);
                        }
                    }
                    //Assign entities where only one user available
                    foreach (var entityUser in entityUsers.Where(a => a.Value.Count == 1))
                    {
                        Console.WriteLine("Assigning all " + entityUser.Key + " to " + entityUser.Value[0].userId + " - " + lookupEntities[entityUser.Key].Count());
                        entityUser.Value[0].TotalEntities += lookupEntities[entityUser.Key].Count();
                        entityUser.Value[0].EntitiesCount[entityUser.Key] = lookupEntities[entityUser.Key].Count();
                        //Ignore these entities because they cannot changed
                        ignoreEntities += entityUser.Value[0].TotalEntities;
                        if (entityUsers.Count(e => e.Value.Contains(entityUser.Value[0])) == 1)
                        {
                            //The user is only assigned to this one entity so ignore user in balancing
                            ignoreUsers++;
                            entityUser.Value[0].Ignored = true;
                        }
                    }
                    //Assign entities where more than one user available
                    foreach (var entityUser in entityUsers.Where(a => a.Value.Count > 1))
                    {
                        var numberOfEntities = lookupEntities[entityUser.Key].Count();
                        for (var i = 0; i < numberOfEntities; i++)
                        {
                            var user = entityUser.Value.OrderBy(u => u.TotalEntities).First();
                            if (!user.EntitiesCount.ContainsKey(entityUser.Key))
                                user.EntitiesCount.Add(entityUser.Key, 0);
                            user.EntitiesCount[entityUser.Key]++;
                            user.TotalEntities++;
                        }
                    }
                    var averagePerUser = 0;
                    var busyUsers = userList.Count(a => a.TotalEntities != 0);
                    //Check to see if there is only one users assigned to each entity
                    if (busyUsers != ignoreUsers)
                    {
                        //Calculate the expected average per user 
                        var totalEntities = entities.Count;
                        averagePerUser = (totalEntities - ignoreEntities) / (busyUsers - ignoreUsers);
                        Console.WriteLine();
                        Console.WriteLine("Total Entities: " + totalEntities);
                        Console.WriteLine("Average Entities: " + averagePerUser);
                        Console.WriteLine();
                        OutputAllocation(userList, averagePerUser);
                        var orderedUserList = userList.OrderByDescending(u => u.TotalEntities).ToList();
                        //Loop through the users and compare to the remaining users
                        for (var i = 0; i < orderedUserList.Count - 1; i++)
                        {
                            for (var j = i + 1; j < userList.Count; j++)
                            {
                                BalanceUsers(userList[i], userList[j], entityUsers, averagePerUser);
                            }
                        }
                        ////Loop through the list in reverse order ?
                        //for (var i = userList.Count - 1; i >= 0; i--)
                        //{
                        //    for (var j = i - 1; j >= 0; j--)
                        //    {
                        //        BalanceUsers(userList[i], userList[j], entityUsers, averagePerUser);
                        //    }
                        //}
                    }
                    OutputAllocation(userList, averagePerUser);
                    Console.WriteLine("Total assigned: " + userList.Sum(u => u.TotalEntities));
                    Console.WriteLine();
                    //Even out remaining difference across entity Type
                    foreach (var entityUser in entityUsers.Where(a => a.Value.Count > 1))
                    {
                        if (entityUser.Value.Any(u => (u.TotalEntities - averagePerUser > 0)))
                        {
                            var users = entityUser.Value.Where(u => (u.TotalEntities - averagePerUser != 0) && u.EntitiesCount[entityUser.Key] > 0);
                            var difference = 0;
                            foreach (var user in users)
                            {
                                difference += user.TotalEntities - averagePerUser;
                                user.TotalEntities -= difference;
                                user.EntitiesCount[entityUser.Key] -= difference;
                            }
                            List<User> fixUsers = null;
                            if (difference < 0)
                            {
                                fixUsers = entityUser.Value.Where(u => (u.EntitiesCount[entityUser.Key] > 0)).ToList();
                            }
                            else
                            {
                                fixUsers = entityUser.Value;
                            }
                            var change = difference / fixUsers.Count();
                            var userCount = fixUsers.Count();
                            foreach (var fixUser in fixUsers)
                            {
                                fixUser.TotalEntities += change;
                                fixUser.EntitiesCount[entityUser.Key] += change;
                                difference -= change;
                                userCount--;
                                //Correct change so that nothing gets lost
                                if (userCount != 0)
                                    change = difference / userCount;
                                else
                                    change = difference;
                            }
                        }
                    }
                    OutputAllocation(userList, averagePerUser);
                    Console.WriteLine("Total assigned: " + userList.Sum(u => u.TotalEntities));
                    Console.WriteLine();
                    foreach (var lookupEntity in lookupEntities)
                    {
                        Console.Write(lookupEntity.Key + " - " + lookupEntity.Count());
                        Console.Write(" Allocation: ");
                        foreach (User user in entityUsers[lookupEntity.Key])
                        {
                            Debug.Assert(user.EntitiesCount[lookupEntity.Key] >= 0);
                            Console.Write(user.userId + " = " + user.EntitiesCount[lookupEntity.Key] + "; ");
                        }
                        Console.WriteLine();
                    }
                }
                Console.ReadLine();
            }
            private static void OutputAllocation(List<User> userList, int averagePerUser)
            {
                //Display allocation after initial assignment
                foreach (var user in userList)
                {
                    var difference = user.TotalEntities - averagePerUser;
                    if (user.Ignored)
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
            private static void BalanceUsers(User firstUser, User secondUser, Dictionary<string, List<User>> entityUsers, int averagePerWorker)
            {
                //Get the difference betweent the current users and the average worker
                var firstUserDiff = firstUser.TotalEntities - averagePerWorker;
                var secondUserDiff = secondUser.TotalEntities - averagePerWorker;
                //Get all the entities which the two users share
                var sharedEntityTypes = entityUsers.Where(x => x.Value.Contains(firstUser) && x.Value.Contains(secondUser)).Select(e => e.Key);
                foreach (var entityType in sharedEntityTypes)
                {
                    var difference = firstUserDiff;
                    if (firstUser.EntitiesCount.Count() > secondUser.EntitiesCount.Count())
                    {
                        difference = -1 * secondUserDiff;
                    }
                    else if (firstUser.EntitiesCount.Count() == secondUser.EntitiesCount.Count())
                    {
                        difference = firstUserDiff - secondUserDiff;
                    }
                    else
                    {
                        difference = firstUserDiff;
                    }
                    difference = firstUserDiff;
                    var maxAllowed = 0;
                    if (difference > 0)
                    {
                        maxAllowed = firstUser.EntitiesCount[entityType] > difference ? difference : firstUser.EntitiesCount[entityType];
                    }
                    else
                    {
                        maxAllowed = secondUser.EntitiesCount[entityType] > Math.Abs(difference) ? difference : -1 * secondUser.EntitiesCount[entityType];
                    }
                    firstUser.EntitiesCount[entityType] -= maxAllowed;
                    firstUser.TotalEntities -= maxAllowed;
                    secondUser.EntitiesCount[entityType] += maxAllowed;
                    secondUser.TotalEntities += maxAllowed;
                    firstUserDiff = firstUser.TotalEntities - averagePerWorker;
                    secondUserDiff = secondUser.TotalEntities - averagePerWorker;
                }
            }
            private static List<Entity> GenerateEntities(int maxEntityTypes, int totalEntities)
            {
                var entityTypes = new List<string>();
                for (var i = 0; i < maxEntityTypes; i++)
                {
                    entityTypes.Add("E" + i);
                }
                var entities = new List<Entity>();
                Random random = new Random();
                for (var i = 0; i < totalEntities; i++)
                {
                    //Randomly allocate user
                    entities.Add(new Entity { Type = entityTypes[random.Next(maxEntityTypes)] });
                    //Used to get even distribution
                    //entities.Add(new Entity { Type = entityTypes[i%maxEntityTypes] });
                    //Used to get specific ratio
                    //var type = "";
                    //switch (i % 3)
                    //{
                    //    case 0:
                    //        type = "E0";
                    //        break;
                    //    case 1:
                    //    case 2:
                    //        type = "E1";
                    //        break;
                    //}
                    //entities.Add(new Entity { Type = type });
                }
                return entities;
            }
        }

    using System.Collections.Generic;
    using System.Linq;
    using RustyLazyLoadTester.Mobile.Services.Models;
    namespace RustyLazyLoadTester.Mobile.Services
    {
    public interface IQueryService
    {
        IEnumerable<User> GetAllUsers(UserStatus status = UserStatus.All,
                                      int limit = 0, int fromRowNumber = 0);
    }
    class QueryService : IQueryService
    {
        public IEnumerable<User> GetAllUsers(UserStatus status, int limit, int fromRowNumber)
        {
            // Assume we have 15 users
            var users = new List<User>();
            for (var i = 0; i < 15; i++)
            {
                var userFirstName = string.Format("firstName_{0}", i);
                var userLastName = string.Format("lastName_{0}", i);
                var userStatus = i % 2 == 0 ? UserStatus.Active : UserStatus.Inactive;
                users.Add(new User(i, userFirstName, userLastName, userStatus));
            }
            if (limit <= 0)
            {
                users = users.Where(x => x.Status == status)
                            .Skip(fromRowNumber)
                            .ToList();
            }
            else
            {
                users = users.Where(x => x.Status == status)
                            .Skip(fromRowNumber)
                            .Take(limit)
                            .ToList();
            }
            return users;
        }
    }
    }

    namespace YourApp
    {
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Web;
        using System.Data.Entity;
        class UserDateTime
        {
            public static readonly UserDateTime Instance = new UserDateTime();
            private UserDateTime() // singleton
            {
                LoadTimezones();
            }
            private Dictionary<int, string> _userTimezones = new Dictionary<int, string>();
            public DateTime GetTime(int userId)
            {
                if (_userTimezones.ContainsKey(userId))
                    return TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById(_userTimezones[userId]));
                else
                    return DateTime.Now; // You could throw an error.
            }
            public void LoadTimezones()
            {
                using (var db = new YourDbContext())
                {
                    _userTimezones = db.UserTimezones.ToDictionary(t => t.UserId, t => t.TimezoneId);
                }
            }
        }
        class UserTimezone
        {
            public int UserId { get; set; }
            public string TimezoneId { get; set; }
        }
        class YourDbContext : DbContext
        {
            public DbSet<UserTimezone> UserTimezones { get; set; }
        }
    }

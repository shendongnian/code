    var root = JsonConvert.DeserializeObject<RootObject>(yourJsonString);
    foreach (var item in root.TotalUsersCount)
    {
        Console.WriteLine(item.AccountStatus);
    }
    var allusers = root.TotalUsersCount.Sum(u => u.TotalUsers);
---
 
    public class TotalUsersCount
    {
        public int AccountStatus { get; set; }
        public int TotalUsers { get; set; }
        public int MemberUsers { get; set; }
        public int CrimsonUsers { get; set; }
    }
    public class RootObject
    {
        public List<TotalUsersCount> TotalUsersCount { get; set; }
    }

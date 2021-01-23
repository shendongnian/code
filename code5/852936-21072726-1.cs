    var joined = (from item1 in loginList 
                             join item2 in users
                             on item1.LoginId equals item2.LoginId
                             orderby item1.LoginId
                              select new UserData
                              {
                                  Password = item1.Password,
                                  LoginId = item2.LoginId,
                                  FullName = item2.FullName,
                                  FatherName = item2.FatherName,
                                  DOB = item2.DOB,
                                  JoinDate = item2.JoinDate
                              }).Distinct(new UserDataComparer()).ToList();
    public class UserData
    {
        public string Password {get;set;}
        public int LoginId {get;set;}
        public string FullName {get;set;}
        public string FatherName {get;set;}
        public DateTime DOB {get;set;}
        public DateTime JoinDate {get;set;}                  
    }
    public class UserDataComparer : IEqualityComparer<UserData>
    {
        public bool Equals(UserData x, UserData y)
        {
            return x.LoginId == y.LoginId;
        }
        public int GetHashCode(UserData obj)
        {
            return obj.LoginId.GetHashCode();
        }
    }

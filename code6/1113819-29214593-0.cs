    public class UserDetails
    {
        public List<string> ManagementCenter;
        public List<string> Group;
        public List<string> Roles;
        public override bool Equals(object obj)
        {
            if (obj is UserDetails)
            {
                var otherUserDetail = obj as UserDetails;
                return string.Equals(GetTestValue(this), GetTestValue(otherUserDetail));
            }
            else
            {
                return false;
            }
        }
        static string GetTestValue(UserDetails userDetail)
        {
            return string.Join(";", userDetail.ManagementCenter) + "|" + string.Join(";", userDetail.Group) + "|" + string.Join(";", userDetail.Roles);
        }
        public override int GetHashCode()
        {
            return GetTestValue(this).GetHashCode();
        }
    }
    [TestMethod]
    public void TestMethod1()
    {
        var a1 = new UserDetails
        {
            ManagementCenter = new List<string> { "JP" },
            Group = new List<string> { "Corporate" },
            Roles = new List<string> { "SuperRole" }
        };
        var a2 = new UserDetails  // same info, different object,
                                  // should still be equal using
                                  // our override of the equals method
        {
            ManagementCenter = new List<string> { "JP" },
            Group = new List<string> { "Corporate" },
            Roles = new List<string> { "SuperRole" }
        };
        var b = new UserDetails // different info, should not be equal
        {
            ManagementCenter = new List<string> { "JP" },
            Group = new List<string> { "Corporate", "Trading", "Supplementary" },
            Roles = new List<string> { "SuperRole" }
        };
        List<UserDetails> userDetailsListFirst = new List<UserDetails>();
        userDetailsListFirst.Add(a1);
        List<UserDetails> userDetailsListSecond = new List<UserDetails>();
        userDetailsListSecond.Add(a2);
        userDetailsListSecond.Add(b);
        //This is now working
        var valuesDifference = userDetailsListSecond.Except(userDetailsListFirst);
    }

        public static List<UserModel> GetUserList(string terms)
        {
            using (DBConnection dbcontext = new DBConnection())
            {
                var termlist = (terms == "") ? new List<string>() : terms.Split(' ').ToList();
                var linqList = (from u in dbcontext.Users
                                where SearchTermMatch(termlist, new List<string>() { u.uLastName, u.uFirstName })
                                select new { u.uLastName, u.uFirstName });
                return linqList.ToList().ConvertAll<UserModel>(u => new UserModel { LastName = u.uLastName, FirstName = u.uFirstName });
            }
        }
        

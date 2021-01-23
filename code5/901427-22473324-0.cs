    struct UserLetter { 
        public Guid Id {get;set;}
        public string Title {get;set;}
        public string AuthorName {get;set;}
    }
    public static IList<UserLetter> GetList()
    {
         return (from l in Letters
                select new UserLetter
                { Id = l.Id, Title = l.Title, AuthorName = l.tblUsers.Name}).ToList();
    }

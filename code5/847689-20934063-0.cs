    public static void UpdateUserinfo(int id, Model model)
    {
        using (Entities context = new Entities())
        using (Entities context2 = new Entities())
        {
            userinfo userinfo = (from u in context.userinfoes where u.Id == id select u).FirstOrDefault();
    
            userinfo.BirthDate = model.Birthdate;
    
            var langauges = (from l in context2.languages where model.LanguageIDs.Contains((int)l.LanguageID) select l);
            foreach (var l in langauges)
            {
                userinfo.languages.Add(l);
    
            }
    
            context.SaveChanges();
        }
    }

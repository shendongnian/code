    public static class EnumNameParser
    {
        public static Preferences ParseString(string enumString)
        {
            var members = typeof(Preferences).GetMembers()
                                                .Where(x => x.GetCustomAttributes(typeof(EnumNameAttribute), false).Length > 0)
                                                .Select(x =>
                                                    new
                                                    {
                                                        Member = x,
                                                        Attribute = x.GetCustomAttributes(typeof(EnumNameAttribute), false)[0] as EnumNameAttribute
                                                    });
    
            foreach(var item in members)
            {
                if (item.Attribute.Name.Equals(enumString))
                    return (Preferences)Enum.Parse(typeof(Preferences), item.Member.Name);
            }
    
            throw new Exception("Enum member " + enumString + " was not found.");
        }
    }

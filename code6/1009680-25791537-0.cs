    class User
    {
        ...
        public override string ToString()
        {
            return UserName + (IsMod ? " (moderator)" : "");
        }
    }

    class Group : ICloneable
    {
        ...
        public override object Clone()
        {
            var entity = base.Clone() as Group;
            entity.Roles = new List<Role>();
            foreach(var r in Roles)
            {
               entity.Roles.Add(r.Clone() as Role);
            }
            ...
            return entity;
        }
    }
    
    class Login: ICloneable
    {
        ...
        public override object Clone()
        {
            var entity = base.Clone() as Login;
            entity.Groups = new List<Group>();
            foreach(var g in Group)
            {
               entity.Groups.Add(r.Clone() as Group);
            }
            ...
            return entity;
        }
    }

    [Serializable]
    public class User, ICloneable, ...
    {
        ...
        public override object Clone()
        {
            var entity = base.Clone() as User;
            entity.Role = Role.Clone() as Role;
            ...
            return entity;
        }

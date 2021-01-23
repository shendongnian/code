    public class UserIdResolver : ValueResolver<UserViewModel, ObjectId>
    {
        protected override ObjectId ResolveCore(UserViewModel source)
        {
            ObjectId objectId = new ObjectId();
            if (!string.IsNullOrEmpty(source.Id))
            {
                objectId = new ObjectId(source.Id);
            }
            return objectId;
        }
    }

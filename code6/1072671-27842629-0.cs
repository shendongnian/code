    public class User : BaseUser
    {
        protected override SyncLists SyncLists
        {
            get { return new UserSyncLists(); }
        }
    }

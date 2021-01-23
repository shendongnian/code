    public class User : BaseUser<UserSyncLists>
    {
        protected override UserSyncLists SyncLists
        {
            get { return new UserSyncLists(); }
        }
    }

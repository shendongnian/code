    public interface IUser
    {
        SyncLists SyncLists { get; }
    }
    public class User : IUser
    {
        SyncLists IUser.SyncLists
        {
            get { return SyncLists; }
        }
        public UserSyncLists SyncLists
        {
            get { return new UserSyncLists();}
        }
    }
    public class EncryptedUser : IUser
    {
        SyncLists IUser.SyncLists
        {
            get { return SyncLists; }
        }
        public EncryptedUserSyncLists SyncLists
        {
            get { return new EncryptedUserSyncLists(); }
        }
    }

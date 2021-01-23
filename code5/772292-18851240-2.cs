    public class UserInfoOverride : IAutoMappingOverride<UserInfo>
    {
        public void Override(AutoMapping<UserInfo> mapping)
        {
            mapping.References(x => x.ActiveTask).Fetch.Join();
        }
    }

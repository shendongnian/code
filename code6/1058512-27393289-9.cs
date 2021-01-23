        public class UserInfoContext : IDisposable
        {
            private static readonly ThreadLocal<UserInfo> UserInfos = new ThreadLocal<UserInfo>();
            public static UserInfo Current
            {
                get 
                {
                    if (UserInfos == null)
                    {
                        throw new InvalidOperationException("UserInfoContext has not been set.");
                    }
                    return UserInfos.Value;
                }
            }
            public static UserInfoContext Create(UserInfo userInfo)
            {
                if (userInfo == null)
                {
                    throw new ArgumentNullException("userInfo");
                }
                if (UserInfos.Value != null)
                {
                    throw new InvalidOperationException("UserInfoContext should not be nested.");
                }
                UserInfos.Value = userInfo;
                return new UserInfoContext();
            }
            private UserInfoContext() { }
            public void Dispose()
            {
                UserInfos.Value = null;
            }
        }

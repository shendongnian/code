        public class UserInfoProvider : Provider<UserInfo>
        {
            protected override UserInfo CreateInstance(IContext context)
            {
                UserInfo UserInfo = new UserInfo();
        
                // Do some complex initialization here.
            
                return userInfo;
            }
        }

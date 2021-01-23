        public partial class Entities : DbContext
        {
            public override int SaveChanges()
            {
                var UserInfo = UserInfoContext.Current;
                // Call the original SaveChanges(), which will save both the changes made and the audit records
                return base.SaveChanges();
            }
        }

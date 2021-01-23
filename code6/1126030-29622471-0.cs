    using System;
    using System.Data.SqlClient;
    using System.Transactions;
    
    namespace UnitTestProject2
    {
        public class User {
            public String Username {get;set;}
            public string Phone { get; set; }
        }
    
        public interface IRepository
        {
            void AddUser(User user);
            bool IsUsernamefree(User user);
        }
    
        public class RepositorySql : IRepository
        {
            private string constr;
            public RepositorySql(string connstr)
            {
                this.constr = connstr;
    
            }
            public void AddUser(User user)
            {
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("insert into phoneNumbers (phone) values (@phone)", conn))
                    {
                        cmd.Parameters.AddWithValue("@phone", user.Phone);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    
        public class UserRegistrationViewModel
        {
            private IRepository rep;
    
            public string ErrorMessage {get;set;}
    
            public UserRegistrationViewModel(IRepository rep)
            {
                this.rep = rep;
            }
    
            public bool AddUser(User user)
            {
                using (TransactionScope trans = new TransactionScope())
                {
                    rep.AddUser(user);
                    ErrorMessage = "";
                    return true;
                }
            }
        }
    }

    using System;
    using System.Data.SqlClient;
    using System.Transactions;
    
    namespace UnitTestProject2
    {
        public class User {
            public String Username {get;set;}
        }
    
        public interface IRepository
        {
            void AddUser(User user);
            bool IsUsernamefree(User user);
        }
    
        public class RepositorySql : IRepository
        {
            SqlConnection conn;
            public void AddUser(User user)
            {
                SqlCommand cmd = new SqlCommand("insert into users (username) values (@usernane)", conn);
                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.ExecuteNonQuery();
            }
    
            public bool IsUsernamefree(User user)
            {
                SqlCommand cmd = new SqlCommand("select count(*) from users where username= @usernane", conn);
                cmd.Parameters.AddWithValue("@username", user.Username);
                object result = cmd.ExecuteScalar();
                if ((int)result == 0)
                {
                    return true;
                }
                return false;
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
    
            public bool RegisterUser(User user)
            {
                using (TransactionScope trans = new TransactionScope())
                {
                    if (rep.IsUsernamefree(user))
                    {
                        rep.AddUser(user);
                        ErrorMessage = "";
                        return true;
                    }
                    else
                    {
                        ErrorMessage = "the user is not free";
                        return false;
                    }
                }
            }
        }
    }

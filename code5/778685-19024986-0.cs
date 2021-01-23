    public class DNNRoleProvider : System.Web.Security.RoleProvider
    {
        public override string[] GetRolesForUser(string username)
        {
            List<string> roles = new List<string>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DNNDB"].ConnectionString))
            {
                con.Open();
                string sql = "SELECT r.RoleName FROM dbo.UserRoles ur INNER JOIN dbo.Roles r on ur.RoleID = r.RoleID INNER JOIN dbo.Users u ON u.UserID = ur.UserID WHERE u.Username = @username";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("username", username));
                SqlDataReader reader = cmd.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        roles.Add(reader["RoleName"].ToString());
                    }
                }
                return roles.ToArray();
            }
        }
        public override bool IsUserInRole(string username, string roleName)
        {
            bool ret = false;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DNNDB"].ConnectionString))
            {
                con.Open();
                string sql = "SELECT count(0) FROM dbo.UserRoles ur INNER JOIN dbo.Roles r on ur.RoleID = r.RoleID INNER JOIN dbo.Users u ON u.UserID = ur.UserID WHERE u.Username = @username and r.RoleName = @rolename";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("username", username));
                cmd.Parameters.Add(new SqlParameter("rolename", roleName));
                SqlDataReader reader = cmd.ExecuteReader();
                using (reader)
                {
                    if (reader.Read())
                    {
                        ret = reader[0].ToString() == "0" ? false : true;
                    }
                }
            }
            return ret;
        }
        //rest of interface implementation
    }

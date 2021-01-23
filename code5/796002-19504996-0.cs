public static List<User> GetUsers(int departmentId)
{
	try
	{
		using (SqlConnection conn = ConnectionHelper.GetConnection("connectionString"))
		{
			return conn.Query<User>("GetUsers", new { DeptId = departmentId }).ToList();			
		}
	}
	catch (Exception ex)
	{
		throw new Exception("Failed to get users", ex);
	}
}

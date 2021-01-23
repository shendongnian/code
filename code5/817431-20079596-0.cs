    using (SqlCommand cmd = new SqlCommand("UPDATE Table SET FIRST_NAME= @FirstName, LAST_NAME= @LastName, BIRTH_DATE=@BirthDate where CUSTOMER_NUMBER = @CustomerNumber"))
    {
        cmd.Parameters.Add(new SqlParameter("FirstName", FirstName));
        cmd.Parameters.Add(new SqlParameter("LastName", LastName));
        cmd.Parameters.Add(new SqlParameter("BirthDate", DateOfBirth));
        cmd.Parameters.Add(new SqlParameter("CustomerNumber", Number));
        // Now, update your database
    } // the SqlCommand gets disposed, because you use the 'using' statement

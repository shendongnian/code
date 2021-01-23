     using (var connection = new SqlConnection(Properties.Settings.Default.CitySecretHRSystemConnectionString))
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            using (var updateEmployees = connection.CreateCommand())
            {
                updateEmployees.CommandText = "INSERT INTO Employees (EmployeeID, FirstName, LastName, PhoneNumber, AccessLevelID, ManagerID, DepartmentID) VALUES (@employeeID, @firstName, @lastName, @phoneNumber, @ accessLevelID, @managerID, @departmentID)";
                updateEmployees.Parameters.AddWithValue("@firstName", firstName);
                updateEmployees.Parameters.AddWithValue("@lastName", lastName);
                updateEmployees.Parameters.AddWithValue("@employeeID", employeeID);
                updateEmployees.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                updateEmployees.Parameters.AddWithValue("@accessLevel", accessLevel);
                updateEmployees.Parameters.AddWithValue("@managerID", managerID);
                updateEmployees.Parameters.AddWithValue("@departmentID", departmentID);
                updateEmployees.ExecuteNonQuery();
            }
       
            using (var updateLogIn = connection.CreateCommand())
            {
                updateLogIn.CommandText = "INSERT INTO LogInDetails (EmployeeID, Username, KeyWord) VALUES (@employeeID, @username, @keyWord)";
                updateLogIn.Parameters.AddWithValue("@employeeID", employeeID);
                updateLogIn.Parameters.AddWithValue("@username", username);
                updateLogIn.Parameters.AddWithValue("@keyWord", password);
                updateLogIn.ExecuteNonQuery();
            }
        }

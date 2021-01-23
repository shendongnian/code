    if (reader.Read())
            {
                public class myObject
                {
                    role = reader.GetString(0);
                    fullName = reader.GetString(1);
                    email = reader.GetString(2);
                }
                sqlCon.Close();
                return myObject;
            }
            else
            {
                return "An error has occurred";
            }

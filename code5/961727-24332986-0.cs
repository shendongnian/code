    static string failReason = "";
    static int valid = 0;
    static string patientName = string.Empty;
    public static void getNewRow()
    {
        try
        {
            string getNewRow = "SELECT * FROM appointments WHERE valid IS NULL";
            DbConnection mysqlDB = new DbConnection();
            MySqlCommand mysqlCommand = new MySqlCommand(getNewRow, mysqlDB.GetLocalMySQLConnection());
            MySqlDataReader reader = mysqlCommand.ExecuteReader();
            while (reader.Read())
            {
                    int id = reader.GetInt32("id");
                    string accountID = reader.GetString("accountID");
                    string appDate = reader.GetString("appDate");
                    string appTime = reader.GetString("apptime");
                    patientName = reader.GetString("patientName");
                    string appPhone = reader.GetString("appPhone");
                    string appPhone2 = reader.GetString("appPhone2");
                    string smsPhone = reader.GetString("smsPhone");
                    string special = reader.GetString("special");
                    string email = reader.GetString("email");
                    string provider = reader.GetString("provider");
                    string location = reader.GetString("location");
                    string other = reader.GetString("other");
                    Console.WriteLine("ID: " + id);
                    Console.WriteLine("AccountID: " + accountID);
                    Console.WriteLine("Appointment Date: " + appDate);
                    Console.WriteLine("Appointment Time: " + appTime);
                    Console.WriteLine("Patient Name: " + patientName);
                    Console.WriteLine("Phone 1: " + appPhone);
                    Console.WriteLine("Phone 2: " + appPhone2);
                    Console.WriteLine("SMS Phone: " + smsPhone);
                    Console.WriteLine("Special: " + special);
                    Console.WriteLine("Email: " + email);
                    Console.WriteLine("Provider: " + provider);
                    Console.WriteLine("Location: " + location);
                    Console.WriteLine("Other: " + other);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.InnerException);
        }
    }
    private static bool validName()
    {
        if (patientName.Length < 20)
        {
            failReason = "Bad Name";
            return false;
        }
        else
        {
            return true;
        }
    }
    private static bool validName()
    {
        if (patientName.Length < 20)
        {
            failReason = "Bad Name";
            return false;
        }
        else
        {
            return true;
        }
    }

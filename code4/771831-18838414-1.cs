    public class Database
    {
        public static Guid InstanceID = new Guid();
    
        //Add the element's values to the database/table to later recall/reorder
        public bool addElement(LogParse log,int num)
        {
            SqlConnection con = new SqlConnection("Data Source=" + Environment.UserName + "-D1SD\\SQLEXPRESS;Initial Catalog=MyDatabase;Integrated Security=True");
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert into storage(ID, InstanceID, Level, LevelInt, DateTime, Counter, Device, Source, Description) values(" + num + ",@Level, @LevelInt, @DataTimeItem,@counterItem,@deviceItem,@sourceItem,@descItem)", con);
                // writing InstanceID
                cmd.Parameters.AddWithValue("@InstanceID", Database.InstanceID);
                cmd.Parameters.AddWithValue("@Level", log.Level);
                cmd.Parameters.AddWithValue("@LevelInt", log.LevelInt);
                cmd.Parameters.AddWithValue("@DataTimeItem", log.TimeStamp);
                cmd.Parameters.AddWithValue("@counterItem", log.SequentialNumber);
                cmd.Parameters.AddWithValue("@deviceItem", log.Device);
                cmd.Parameters.AddWithValue("@sourceItem", log.Source);
                cmd.Parameters.AddWithValue("@descItem", log.Description);
                cmd.ExecuteNonQuery();
                con.Close();
    
            }
            catch (Exception ee)
            {
                return false;
            }
            return true;
        }
    
        //outputs a string array with all the values in the database
        public LogParse[] readValue(int start, int end)
        {
            SqlConnection con = new SqlConnection("Data Source=" + Environment.UserName + "-D1SD\\SQLEXPRESS;Initial Catalog=MyDatabase;Integrated Security=True");
            con.Open();
            LogParse[] s = new LogParse[end - start];
            try
            {
                // select with InstanceID
                using (var oCommand = new SqlCommand("SELECT * From storage WHERE InstanceID = @InsID ID BETWEEN @Start AND @End", con))
                {
                    oCommand.Parameters.AddWithValue("@Start", start);
                    oCommand.Parameters.AddWithValue("@End", end);
                    oCommand.Parameters.AddWithValue("@InsID", Database.InstanceID);
                    using (var oReader = oCommand.ExecuteReader())
                    {
                        int i = 0;
                        while (oReader.Read() && i < end-start)
                        {
                            //s[i] = oReader.GetString(1) + oReader.GetString(2) + oReader.GetString(3);
                            String Level = oReader.GetString(1);
                            Int32 LevelInt = oReader.GetInt32(2);
                            String Datetime = oReader.GetString(3);
                            Int16 SequentialNumber = (Int16)oReader.GetValue(4);
                            String Device = oReader.GetString(5);
                            String Source = oReader.GetString(6);
                            String Description = oReader.GetString(7);
    
                            s[i] = new LogParse();
                            s[i].Level = Level;
                            s[i].LevelInt = LevelInt;
                            s[i].TimeStamp = DateTime.Parse(Datetime);
                            s[i].SequentialNumber = SequentialNumber;
                            s[i].Device = Device;
                            s[i].Description = Description;
                            s[i].Source = Source;
                            ++i;
                        }
                    }
                }
            }
            catch
            {
    
            }
            con.Close();
            return s;
        }
    }

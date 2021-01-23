    public static class Utilities 
    {
        public static void loadFromTuzel(ComboBox cbo)
        {
            /// All of you other logic
            while (myReader.Read())
            {
                cbo.Items.Add(myReader["name"].ToString() + " " + 
                    myReader["Surname"].ToString());
            }
        }
    }

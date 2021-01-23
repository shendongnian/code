        public static int MyExecuteNonQuery(this SqlCommand command)
        {
            command.Connection.Open();
            var buff = command.ExecuteNonQuery();
            command.Connection.Close();
            return buff;
        }

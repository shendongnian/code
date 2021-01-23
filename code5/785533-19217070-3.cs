        private static Test FillTestRecord(IDataRecord dr)
        {
            Test test = new Test();
            int tempId;
            if (TryParseDataRow<int>(dr, "ID", out tempId))
            {
                test.Id = tempId;
            }
            return test;
        }
        private static bool TryParseDataRow<T>(IDataRecord record, string column, out T value)
        {
            value = default(T);
            bool success = true;
            if (record == null)
            {
                //nothing you can do with a null object
                success = false;
            }
            else if (!record.HasColumn(column)) //not sure if this will throw exeption or return null. you can check in your project
            {
                success = false;
            }
            else if (record[column] != typeof(T))
            {
                //object was of an unexpected type
                success = false;
            }           
            else
            {
                //cast the value into the output parameter
                value = (T)record[column];
            }
            return success;
        }

        private static Test FillTestRecord(IDataRecord dr)
        {
            Test test = new Test();
            int tempId;
            if (TryParseDataRow<int>(dr,"ID", out tempId))
            {
                test.Id = tempId;
            }
            return test;
        }
        private static bool TryParseDataRow<T>(IDataRecord record, string colum, out T value)
        {
            value = default(T);
            bool success = true;
            if (obj == null)
            {
                //nothing you can do with a null object
                success = false;
            }
            else if (obj.GetType() != typeof(T))
            {
                //object was of an unexpected type
                success = false;
            }
            else if (record[colum] == null) //not sure if this will throw exeption or return null. you can check in your project
            {
                 success = false;
            }
            else
            {
                //cast the value into the output parameter
                value = (T)record[colum];
            }
            return success;
        }

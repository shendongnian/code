        public static bool WriteCsvFile(string path, StringBuilder stringToWrite)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path, false))         //false in ordre to overwrite the file if it already exists
                {
                    sw.Write(stringToWrite);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

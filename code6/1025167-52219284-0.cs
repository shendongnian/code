        public static bool AdminCheck(string machineName)
        {
            if (Directory.Exists(string.Format("\\\\{0}\\admin$", machineName)))
            {
                return true;
            }
            return false;
        }

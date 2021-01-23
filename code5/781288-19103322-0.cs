        private static void OnInfoMessage(Object sender, OdbcInfoMessageEventArgs args)
        {
            StringBuilder sb = new StringBuilder();
            if (args != null && args.Errors != null &&
                args.Errors.Count > 0)
            {
                foreach (OdbcError error in args.Errors)
                {
                    sb.AppendLine(error.Message);
                }
                LogUtil.WriteException("InsertRow", new Exception(sb.ToString()));
            }
            if (!String.IsNullOrEmpty(args.Message))
            {
                LogUtil.Write("InsertRow", args.Message);
            }
            
        }

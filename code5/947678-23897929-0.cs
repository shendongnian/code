    private static void conn_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            if (e.Errors != null)
            {
                for (int i = 0; i < e.Errors.Count; i++)
                {
                    sqlMessages.AppendLine(e.Errors[i].Message);
                }
            }
        }

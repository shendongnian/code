             if(!string.IsNullorEmpty(lineuser)
             {   
                string[] values = lineuser.Split(' '); //<------the line's error
                int userid, factoriduser;
                foreach (string value in values)
                {
                    userid = Convert.ToInt32(values[0]);
                    factoriduser = Convert.ToInt32(values[1]);
                    userscore = Convert.ToSingle(values[2]);
                    a[userid][factoriduser] = userscore;
                }
             }

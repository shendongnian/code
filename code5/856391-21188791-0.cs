                    TdConnectionStringBuilder builder=new TdConnectionStringBuilder();
                    builder.Add("Data Source", "xxx");
                    builder.Add("User ID", "vvv");
                    builder.Add("Password", "bbb");
                    TdConnection cn = new TdConnection(builder.ConnectionString);
                    cn.Open();

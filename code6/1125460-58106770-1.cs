                return new RedisConfiguration()
            {
                AbortOnConnectFail = true,
                Hosts = new RedisHost[] {
                                          new RedisHost() 
                                          {
                                              Host = ConfigurationManager.AppSettings["RedisCacheAddress"].ToString(),
                                              Port = 6380
                                          },
                                        },
                ConnectTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["RedisTimeout"].ToString()),
                Database = 0,
                Ssl = true,
                Password = ConfigurationManager.AppSettings["RedisCachePassword"].ToString(),
                ServerEnumerationStrategy = new ServerEnumerationStrategy()
                {
                    Mode = ServerEnumerationStrategy.ModeOptions.All,
                    TargetRole = ServerEnumerationStrategy.TargetRoleOptions.Any,
                    UnreachableServerAction = ServerEnumerationStrategy.UnreachableServerActionOptions.Throw
                },
                PoolSize = 50
            };

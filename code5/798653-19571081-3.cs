            if (isSync) //isSync = if threads syncroized
            {
                if (Monitor.TryEnter(users[ind]))
                {
                    try
                    {
                        users[ind].FinishSync = users[ind].FinishSync - sum;
                    }
                    finally
                    {
                        Monitor.Exit(users[ind]);
                    }
                }
            }
            else
            {
                lock (users[ind])
                {
                    users[ind].FinishUnsync = users[ind].FinishUnsync - sum;
                }
            }

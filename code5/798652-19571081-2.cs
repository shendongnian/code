            if (isSync) //isSync = if threads syncroized
            {
                // synchronized. prevent concurrent updates.
                lock (users[ind])
                {
                    users[ind].FinishSync = users[ind].FinishSync - sum;
                }
            }
            else
            {
                // unsynchronized. It's a free-for-all.
                users[ind].FinishUnsync = users[ind].FinishUnsync - sum;
            }

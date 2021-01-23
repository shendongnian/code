            try
            {
                Type transType = typeof (System.Transactions.TransactionManager);
                FieldInfo cachedMaxTimeOut = transType.GetField("_cachedMaxTimeout", BindingFlags.NonPublic | BindingFlags.Static);
                FieldInfo maximumTimeOut = transType.GetField("_maximumTimeout", BindingFlags.NonPublic | BindingFlags.Static);
                if (null != cachedMaxTimeOut)
                {
                    cachedMaxTimeOut.SetValue(null, true);
                }
                if (null != maximumTimeOut)
                {
                    maximumTimeOut.SetValue(null, timeout);
                }
            }
            catch(Exception ex)
            {
                //Exception handling or logging.
            }

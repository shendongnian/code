      internal static long Insert<T>(this IDbCommand dbCmd, T obj, bool selectIdentity = false)
            {
                OrmLiteConfig.DialectProvider.PrepareParameterizedInsertStatement<T>(dbCmd);
    
                OrmLiteConfig.DialectProvider.SetParameterValues<T>(dbCmd, obj);
    
                if (selectIdentity)
                    return OrmLiteConfig.DialectProvider.InsertAndGetLastInsertId<T>(dbCmd);
    
                return dbCmd.ExecNonQuery();
            }

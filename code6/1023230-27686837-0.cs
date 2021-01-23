    public static IDbTransaction ToDbTransaction(this IDbTransaction dbTrans)
        {
            var hasDbTrans = dbTrans as IHasDbTransaction;
            return hasDbTrans != null
                ? hasDbTrans.Transaction
                : dbTrans;
        }

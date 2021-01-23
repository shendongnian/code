    // We can only pull the nest over a Join/Apply if it has keys, so
    // we can order things; if it doesn't have keys, we throw a NotSupported
    // exception.
    foreach (var chi in n.Children)
    {
        if (op.OpType != OpType.MultiStreamNest
            && chi.Op.IsRelOp)
        {
            var keys = Command.PullupKeys(chi);
    
            if (null == keys
                || keys.NoKeys)
            {
                throw new NotSupportedException(Strings.ADP_KeysRequiredForJoinOverNest(op.OpType.ToString()));
            }
        }
    }

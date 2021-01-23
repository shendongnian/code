    Dictionary<int, Transaction> dict = new Dictionary<int, Transaction>();
    foreach (OldTransaction ot in whateverSource) {
        Transacton t = null;
        if (!dict.TryGet(ot.ID, out t)) {
            t = new Transaction(ot.ID);
            dict.Add(ot.ID, t);
        }
        t.items.Add(ot.ToItem());
    }

    private static void Dispose<T>(ref T obj) where T : class, IDisposable {
        if(obj != null) {
            try { obj.Dispose(); } catch {}
            obj = null;
        }
    }
    public virtual void Dispose() {
        Dispose(ref stream);
        Dispose(ref log);
    }

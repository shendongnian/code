    public void Invoke(int dispId, ref Guid riid, int lcid, System.Runtime.InteropServices.ComTypes.INVOKEKIND wFlags, ref System.Runtime.InteropServices.ComTypes.DISPPARAMS pDispParams, out object result, IntPtr pExcepInfo, IntPtr puArgErr)
    {
        string name;
        dispIdNameMap.TryGetValue(dispId, out name);
        if (result != null)
        {
            result[0] = name;
        }
    }

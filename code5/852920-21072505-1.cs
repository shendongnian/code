    private Task C_Async(int id)
    {
        // This method executes very fast
        var idTemp = paddID(id);
        return D_Async(idTemp);
    }
    private Task D_Async(string id)
    {
        // This method executes very fast
        return E_Async(id);
    }

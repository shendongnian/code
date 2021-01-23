    public static void Delete(ref Prot[] pack, Prot prot)
    {
        var temp = new List<Prot>(pack);
        temp.Remove(prot);
        pack = temp.ToArray();
    }

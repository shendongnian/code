    public void DestroyProduct(string KodKreskowy)
    {
        for (int i = 0; i < dictionary.Count; i++)
        {
            dictionary.Remove(KodKreskowy);
        }
    }

    public void AskServer(string url, params object[] args)
    {
        WWWForm form = new WWWForm(url);
        for (int i = 0; i < args.GetLength(0); i++)
            form.Addfield(args[i].ToString(), args[++i]);
    }

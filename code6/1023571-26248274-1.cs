    string Parse(string value, List<ClientData> list)
    {
        string[] parts = value.Split(new string[1] { "</ClientData>" }, StringSplitOptions.None);
        for (int i = 0; i < parts.Length - 1; i++)
            list.Add(new ClientData(parts[i]));
        return parts[parts.Length - 1];
    }

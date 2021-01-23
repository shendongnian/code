    public void SetDetail(string name, string value)
    {
        if (this.Details.ContainsKey(name))
        {
            this.Details[name] = value;
        }
        else
        {
            this.Details.Add(name, value);
        }
    }

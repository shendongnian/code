    public void Thing(int x, string s = "", params Hello[] hellos)
    {
    }
    public void Thing(int x, params Hello[] hellos)
    {
        this.Thing(x, string.Empty, hellos);
    }

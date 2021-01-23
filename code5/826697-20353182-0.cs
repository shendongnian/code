    public Region Clone()
    {
        var result = new Region();
        result.Id = this.Id;
        result.Name = this.Name;
        return result;
    }

    public override string ToString()
    {
      if (!this.HasValue)
        return ""; //return empty string when value is null
      else
        return this.value.ToString();
    }

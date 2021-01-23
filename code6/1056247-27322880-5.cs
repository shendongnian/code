    public Datum(IList<T> obj)
    {
        this.objects =
          JsonConvert.DeserializeObject<IList<T>>(JsonConvert.SerializeObject(obj));
        this.Count = obj.Count;
    }

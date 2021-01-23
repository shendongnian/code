    protected Creature()
    {
      _classification = new T();
    }
    private T _classification;
    public virtual T Classification
    {
      get { return _classification; }
      protected set { _classification = value; }
    }

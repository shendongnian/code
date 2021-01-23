    object IEnumerable.Current
    {
        // this calls the implicitly implemented generic property
        get { return this.Current; }
    }
    
    public T Current
    {
        get { return this.current; } // or however you want to do it
    }

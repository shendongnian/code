    public new Field this[int key]
    {
        get
        {
            if (!this.Contains(key))
            {
                Field field = null;
                // The loading code of the field + assigning the field object.
  
                this.Add(field);
            }
            return Dictionary[key];
        }
    }

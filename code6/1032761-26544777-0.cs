    public string ProductName
    {
        get
        {
            if (this.yourEntityReference.EntityKey == null) return "";
            else return (string)this.yourEntityReference
                .EntityKey.EntityKeyValues[0].Value;
        }
        set
        {
            this.yourEntityReference.EntityKey
               = new EntityKey("YourDB.YourTable", "ColumnName", value);
        }
    }

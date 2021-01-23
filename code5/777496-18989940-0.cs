    [global::System.Runtime.Serialization.OnSerializingAttribute()]
    [global::System.ComponentModel.EditorBrowsableAttribute(EditorBrowsableState.Never)]
    public void OnSerializing(StreamingContext context)
    {
        this.serializing = true;
        // custom function to handle my logic
        this.ClearPassword();
    }
    

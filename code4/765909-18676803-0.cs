    [NotMapped]
    public SomeObject BigComplexObject
    {
        get { return new SomeObject(this.BigComplexObjectString); }
        set { this.BigComplexObjectString = value.ToXmlString(); }
    }

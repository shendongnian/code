    public override bool IsReadOnly()
    {
        return false;
    }
    protected override ConfigurationElement CreateNewElement()
    {
        return new Question();
    }
    protected override object GetElementKey(ConfigurationElement element)
    {
        return ((Question)element).id;
    }
    public Question GetQuestion(int id)
    {
        get
        {
           return (Question)this.BaseGet(id);
        }
    }
}

    public void Register()
    {
        AttributeTableBuilder builder = new AttributeTableBuilder();
        builder.AddCustomAttributes(
            typeof(MyActivity),
            new DesignerAttribute(typeof(MyActivityDesigner)));
        MetadataStore.AddAttributeTable(builder.CreateTable());
    }

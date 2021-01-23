    private Roller roller;
    [Editor(typeof(RolCollectionEditor), typeof(System.Drawing.Design.UITypeEditor))]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [PersistenceMode(PersistenceMode.InnerProperty)]
    public Roller Roller
    {
        get
        {
            if (roller == null)
            {
                roller = new Roller();
            } return roller;
        }
    }

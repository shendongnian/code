    private Theme theme;
    [DisplayName("Theme")]
    [Category("Appearance")]
    [Description("Specifies the Theme for this form.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public Theme Theme
    {
        get { return theme; }
        set
        {
            theme = value;
            Invalidate();
        }
    }

    /// <summary>
    /// Don't use this to get or set.
    /// This must however be kept as public or db.CreateTable()
    /// will not insert this field into the database.
    /// </summary>
    [NullSetting(NullSetting = NullSettings.NotNull)]
    [Column("type")]
    public int _type { get; set; }
    
    /// <summary>
    /// This field is ignored by db.CreateTable().
    /// </summary>
    [Ignore]
    public FormType Type
    {
        get
        {
            return (FormType)_type;
        }
        set
        {
            _type = (int)value;
        }
    }

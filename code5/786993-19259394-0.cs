    [Required()]
    [DataType(DataType.Url)]
    [DisplayFormat(DataFormatString = "{0,20}")]
    [UIHint("ShortUrl")]
    public string Link { get; set; }

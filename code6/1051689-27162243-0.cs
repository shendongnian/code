    [Parameter(ParameterSetName = ParameterSetObject,
               ValueFromPipelineByPropertyName = true,
               HelpMessage = "The encoding to use for string InputObjects.  Valid values are: ASCII, UTF7, UTF8, UTF32, Unicode, BigEndianUnicode and Default.")]
    [ValidateNotNullOrEmpty]
    [ValidateSet("ascii", "utf7", "utf8", "utf32", "unicode", "bigendianunicode", "default")]
    public StringEncodingParameter StringEncoding
    {
        get { return _encoding; }
        set { _encoding = value; }
    }

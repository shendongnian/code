    public static bool IsMinimallyValidXml( Stream stream )
    {
      XmlReaderSettings settings = new XmlReaderSettings
        {
          CheckCharacters              = true                          ,
          ConformanceLevel             = ConformanceLevel.Document     ,
          DtdProcessing                = DtdProcessing.Ignore          ,
          IgnoreComments               = true                          ,
          IgnoreProcessingInstructions = true                          ,
          IgnoreWhitespace             = true                          ,
          ValidationFlags              = XmlSchemaValidationFlags.None ,
          ValidationType               = ValidationType.None           ,
        } ;
      bool isValid ;
      using ( XmlReader xmlReader = XmlReader.Create( stream , settings ) )
      {
        try
        {
          while ( xmlReader.Read() )
          {
            ; // This space intentionally left blank
          }
          isValid = true ;
        }
        catch (XmlException)
        {
          isValid = false ;
        }
      }
      return isValid ;
    }
    
    static void Main( string[] args )
    {
      string text = "<foo>This &SomeEntity; is about as simple as it gets.</foo>" ;
      Stream stream = new MemoryStream( Encoding.UTF8.GetBytes(text) ) ;
      bool isValid = IsMinimallyValidXml( stream ) ;
      return ;
    }

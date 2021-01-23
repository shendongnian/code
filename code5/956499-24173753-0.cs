    TextReader CreateReader()
    {
        if( UploadedFile )
            return new System.IO.StreamReader( LocalFileName );
        else
            return new System.IO.StringReader( Input );
    }

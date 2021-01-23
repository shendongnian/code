    {
      TextReader TheReader;
      if( UploadedFile ) { TheReader = new System.IO.StreamReader( LocalFileName ); }
      else { TheReader = new System.IO.StringReader( Input ); }
      using (TheReader) {
        //Use The reader
      }
    }

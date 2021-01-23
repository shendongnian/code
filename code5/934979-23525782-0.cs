    public bool VerifyXml( string SignedXmlDocumentString )
    {
        byte[] stringData = Encoding.UTF8.GetBytes( SignedXmlDocumentString );
        using ( MemoryStream ms = new MemoryStream( stringData ) )
            return VerifyXmlFromStream( ms );
    }

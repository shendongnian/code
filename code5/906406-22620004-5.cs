    while( reader.Read() )
    {
        if( reader.Value != null )
        {
            switch( reader.Depth )
            {
                case 2:
                    if( reader.TokenType == JsonToken.PropertyName && reader.Value.ToString() == "count" )
                    {
                        reader.Read();
                        root.objectContainer.count = Convert.ToInt32( reader.Value );
                    }
                    break;
                case 3:
                    newBase = new Base();
                    root.objectContainer.objects.bases.Add( newBase );
                    break;
                case 4:
                    if( reader.TokenType == JsonToken.PropertyName && reader.Value.ToString() == "name" )
                    {
                        reader.Read();
                        newBase.name = reader.Value.ToString();
                    }
                    if( reader.TokenType == JsonToken.PropertyName && reader.Value.ToString() == "parent" )
                    {
                        reader.Read();
                        newBase.parent = reader.Value.ToString();
                    }
                    if( reader.TokenType == JsonToken.PropertyName && reader.Value.ToString() == "status" )
                    {
                        reader.Read();
                        newBase.status = reader.Value.ToString();
                    }
                    break;
            }
        }
    }

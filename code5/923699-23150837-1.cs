    BlobBase blob = this.statement.CreateBlob();
    if( this.Parameters[ index ].Value is System.IO.Stream )
    {
      blob.Write( (System.IO.Stream)this.Parameters[ index ].Value );
    }
    else
    {
       blob.Write( (byte[])this.Parameters[ index ].Value );
    }

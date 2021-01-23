    string updateSQL = string.Format( @"UPDATE {0} SET {1} = :DATA WHERE {2}",    tableName, colName, whereStr );
    using( FbCommand getBlobCmd = new FbCommand( updateSQL, conn ) )
    {
      try
      {
        FbParameter parBlob = new FbParameter( "DATA", FbDbType.Binary );
        parBlob.Direction = ParameterDirection.Input;
        parBlob.Value = blobFile.InnerStream;//input FileStream
        getBlobCmd.Parameters.Add( parBlob );
        getBlobCmd.Prepare();
        getBlobCmd.ExecuteNonQuery();
      }
      catch{}
    }

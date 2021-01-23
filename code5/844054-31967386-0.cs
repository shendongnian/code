    	public bool ReadDBBlobToFile ( MySqlDataReader parReader, string parFilePath, string parColumnName )
		{
			bool retResult = false;
			if ( parReader == null )
			{
				throw new NullReferenceException ( "MySqlCommand is null" );
			}
			
			int id = parReader.GetOrdinal(parColumnName);
			if ( !parReader.IsDBNull ( id ) )
			{
				string dir = Path.GetDirectoryName(parFilePath);
				if ( string.IsNullOrWhiteSpace ( dir ) )
				{
					dir = Path.GetDirectoryName ( Path.GetFullPath ( parFilePath ) );
				}
				Directory.CreateDirectory ( dir );
				
				using ( FileStream fs = new FileStream ( parFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite ) )
				{
					using ( BinaryWriter bw = new BinaryWriter ( fs ) )
					{
						long CurrentIndex = 0;
						long len = 100;
						byte[] blob = new byte[len];
						
						long BytesReturned = parReader.GetBytes ( id, CurrentIndex, blob, 0, ( int ) len );
						
						while ( BytesReturned == len )
						{
							bw.Write ( blob );
							bw.Flush ( );
							CurrentIndex += len;
							BytesReturned = parReader.GetBytes ( id, CurrentIndex, blob, 0, ( int ) len );
						}
						if ( BytesReturned > 0 )
						{
							bw.Write ( blob, 0, ( int ) BytesReturned );
						}
						bw.Flush ( );
						bw.Close ( );
					}
					fs.Close ( );
				}
				retResult = true;
			}
			else
			{
				retResult = false;
			}
			return retResult;
		}
			
		
		myConn.Open();
			using (MySqlDataReader myReader = view.ExecuteReader())
			{
				while (myReader.Read())
				{
					if (saveFileDialog1.ShowDialog() == DialogResult.OK)
					{
						string strFilename = saveFileDialog1.FileName;
						ReadDBBlobToFile ( myReader, strFilename, "word" );
					}
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}

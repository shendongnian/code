 		StorageFile file = await dataFolder.CreateFileAsync(filename, CreationCollisionOption.OpenIfExists);
        // Serialize the object
        XmlSerializer serializer = new XmlSerializer(obj.GetType());
        // Write the data from the textbox.
        using (var s = await file.OpenStreamForWriteAsync())
        {
            try
            {
                s.Position = s.Seek(0, SeekOrigin.End);
				
				using (var x = new XmlTextWriter(s, Text.UTF8Encoding))
				{
					x.Setting.OmitXmlDeclaration = true;
                	serializer.Serialize(x, obj);
				}
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.Message);
            }
            finally{
                s.Close();
            }
        }

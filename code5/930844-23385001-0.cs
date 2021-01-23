    				MemoryStream MemStream = new MemoryStream();
				BufferedStream Stream2 = new BufferedStream(_ObjResponse.ResponseStream);
				byte[] Buffer = new byte[0x2000];
				int Count;
				while ((Count = Stream2.Read(Buffer, 0, Buffer.Length)) > 0)
				{
					MemStream.Write(Buffer, 0, Count);
				}
				// Pfad auslesen
				string TempFile = Path.GetTempFileName();
				//Stream zum Tempfile öffnen
				FileStream Newfile = new FileStream(TempFile,FileMode.Create);
				//Stream wieder auf Position 0 ziehen
				MemStream.Position = 0;
				// in Tempdatei speichern
				MemStream.CopyTo(Newfile);
				Newfile.Close();
				// Endgültigen Speicherpunkt prüfen und Tempdatei dorthin schieben
				if (File.Exists(Filename))
				{
					File.Delete(Filename);
				}
				File.Move(TempFile, Filename);

    foreach (Membre noms in p_nom)
    {
		try
		{			
            string websiteName = "https://twitter.com/" + noms.NomMembre;
            string source = (new WebClient()).DownloadString(websiteName);
			
            if (source.Contains("<title>Twitter / ?</title>"))
            {
                p_disponible.Add(new MembreVerifier(noms.NomMembre));
            }
		}
		catch (WebException ex)
		{
			using (var stream = ex.Response.GetResponseStream())
			{
				// Copy stream to buffer.
				var buffer = new byte[stream.Length];
				stream.Read(buffer, 0, (int)stream.Length);
				
				// Decode byte array to UTF-8 string.
				var content = Encoding.UTF8.GetString(buffer);
                                
                // TODO: Use content.
			}
		}
    }

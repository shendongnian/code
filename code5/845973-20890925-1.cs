    foreach (Membre noms in p_nom)
    {
        string source = "";
		try
		{			
            string websiteName = "https://twitter.com/" + noms.NomMembre;
            source = (new WebClient()).DownloadString(websiteName);		
		}
		catch (WebException ex)
		{
			using (var stream = ex.Response.GetResponseStream())
			{
				// Copy stream to buffer.
				var buffer = new byte[stream.Length];
				stream.Read(buffer, 0, (int)stream.Length);
				
				// Decode byte array to UTF-8 string.
				source = Encoding.UTF8.GetString(buffer);
			}
		}
        if (source.Contains("<title>Twitter / ?</title>"))
        {
             p_disponible.Add(new MembreVerifier(noms.NomMembre));
        }
    }

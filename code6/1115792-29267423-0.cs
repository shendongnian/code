    if (!szSoundPlayerPath.Equals(szPath))
    {
    	try
    	{
    		this.Invoke((MethodInvoker)delegate 
    		{
    			m_SoundPlayer.Stop();
    			m_SoundPlayer.Open(new Uri(szPath, UriKind.Relative));
    			m_SoundPlayer.Play();
    		});
    	}
    	catch (Exception ex)
    	{
    		Console.WriteLine(ex.Message);
    	}
    }
     

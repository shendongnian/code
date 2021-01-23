    public void chupala()
    {
        for (int i = 0; i < procs.Length; i++)
        {
            if (Regex.IsMatch(procs[i].ProcessName, @"\bFirefox\b"))
            {
                using (var player = new SoundPlayer(@"C:\bass.wav"))
                {
                    player.Play();
                }
            }
        }
    }

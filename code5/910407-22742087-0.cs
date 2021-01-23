        public void chupala()
        {
            for (int i = 0; i < procs.Length; i++)
            {
              bool b;
              // Use Regex in here, assume that ProcessName of Firefox app is Firefox
              b = Regex.IsMatch(procs[i].ProcessName, @"(^|\s)Firefox(/s|$)");
              if (b)
              {
                    using (SoundPlayer player = new SoundPlayer("C:\\bass.wav"))
                    {
                        player.Play();
                    }
               }
            }
         }

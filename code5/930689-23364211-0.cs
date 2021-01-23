    public CDPlayer (int Voice, int CurrentTrack, string Command)
        {
          this.Voice = VolumeStatus(Voice);
          this.CurrentTrack = CurrentTrack;
          this.Command = Command;
        }

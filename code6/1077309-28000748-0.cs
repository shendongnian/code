    public string SelectedCustomMusic
        {
            get
            {
                return this.selectedCustomMusic;
            }
            set
            {
                if (value != null)
                {
                    this.selectedCustomMusic = value;
                    this.MusicSource = this.selectedCustomMusic;
                    base.OnPropertyChanged();
                }
            }
        }

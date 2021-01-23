    var musicInput : GameObject;
     private var aud : AudioFileReader;
     private var craftClip : AudioClip;
     private var AudioData : float[];
     private var readBuffer : float[];
     private var soundSystem : AudioSource;
     private var musicPath : String[];
     //Check if there's a pref set for the music path. Use it AND add all the files from it
     function CheckMusic()
     {
         var pathname = musicInput.GetComponent.<InputField>();
             if(PlayerPrefs.HasKey("musicpath") == false)
                 {
                     PlayerPrefs.SetString("musicpath", "Enter Music Directory");
                 }
                 else
                     {
                         pathname.text = PlayerPrefs.GetString("musicpath");
                         musicPath = Directory.GetFiles(PlayerPrefs.GetString("musicpath"),"*.mp3");
                     }
         
     }
     
     function LoadSong(songToPlay : int)
     {
     //Download the song via WWW
     var currentSong : WWW = new WWW(musicPath[songToPlay]);
     
     //Wait for the song to download
     if(currentSong.error == null)
         {
             //Set the title of the song
             playingSong.text = Path.GetFileNameWithoutExtension(musicPath[songToPlay]);
             //Parse the file with NAudio
             aud = new AudioFileReader(musicPath[songToPlay]);
             
             //Create an empty float to fill with song data
             AudioData = new float[aud.Length];
             //Read the file and fill the float
             aud.Read(AudioData, 0, aud.Length);
             
             //Create a clip file the size needed to collect the sound data
             craftClip = AudioClip.Create(Path.GetFileNameWithoutExtension(musicPath[songToPlay]),aud.Length,aud.WaveFormat.Channels,aud.WaveFormat.SampleRate, false);
             //Fill the file with the sound data
             craftClip.SetData(AudioData,0);
             //Set the file as the current active sound clip
             soundSystem.clip = craftClip;
         }
     }

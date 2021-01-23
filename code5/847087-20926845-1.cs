    public class MyDataClass
    {
        public string Artist { get; set; }
        public string Duration { get; set; }
    
        public MyDataClass(string artist, int duration)
        {
            TimeSpan span = TimeSpan.FromSeconds(duration);
            Artist = artist;
            Duration = span.ToString();
        }
    }
    
    public void AudioGet()
    {
        var clientAudio = new WebClient();
        clientAudio.OpenReadCompleted += clientAudio_OpenReadCompleted;
        string uri = "https://api.vk.com/method/audio.get?";
        clientAudio.OpenReadAsync(new Uri(uri));
    }
    
    private void clientAudio_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
    {
        List<MyDataClass> audioList = new List<MyDataClass>();
        var root = new DataContractJsonSerializer(typeof(RootObject));
        RootObject rootObject = (RootObject)root.ReadObject(e.Result);
    
        foreach (var myClass in rootObject.response)
        {
            audioList.Add(new MyDataClass(myClass.artist, myClass.duration));
        }
    
        MyListBox.ItemsSource = audioList;
    }
    
    #region JsonDataClass
    public class Response
    {
        public string artist { get; set; }
        public int duration { get; set; }
    }
    
    public class RootObject
    {
        public List<Response> response { get; set; }
    }
    #endregion

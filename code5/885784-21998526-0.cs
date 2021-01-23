    private static SpeechSynthesizer speaker;
    public static void Main(String[] args){
      speaker = new SpeechSynthesizer();
      speaker.SetOutputToDefaultAudioDevice();
      speaker.Rate = 1;
      speaker.Volume = 100;
      speaker.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult);
      speaker.SpeakAsync("Hello World"); 
    }
   
    private static List<VoiceInfo> GetInstalledVoices() {
      var listOfVoiceInfo = from voice
                            in  speaker.GetInstalledVoices()
                            select voice.VoiceInfo;
      return listOfVoiceInfo.ToList<VoiceInfo>();
    }

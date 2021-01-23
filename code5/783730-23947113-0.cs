    //reference System.Speech
    using System.Speech.Synthesis; 
    using System.Speech.AudioFormat;
    //reference Nuget Package NAudio.Lame
    using NAudio.Wave;
    using NAudio.Lame; 
    using (SpeechSynthesizer reader = new SpeechSynthesizer()) {
        //set some settings
        reader.Volume = 100;
        reader.Rate = 0; //medium
        //save to memory stream
        MemoryStream ms = new MemoryStream();
        reader.SetOutputToWaveStream(ms);
        //do speaking
        reader.Speak("This is a test mp3");
        //now convert to mp3 using LameEncoder or shell out to audiograbber
        ConvertWavStreamToMp3File(ref ms, "mytest.mp3");
    }
    public static void ConvertWavStreamToMp3File(ref MemoryStream ms, string savetofilename) {
        //rewind to beginning of stream
        ms.Seek(0, SeekOrigin.Begin);
        using (var retMs = new MemoryStream())
        using (var rdr = new WaveFileReader(ms))
        using (var wtr = new LameMP3FileWriter(savetofilename, rdr.WaveFormat, LAMEPreset.VBR_90)) {
            rdr.CopyTo(wtr);
        }
    }
    

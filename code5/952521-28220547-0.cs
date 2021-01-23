    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Net;
    using Newtonsoft.Json;
    namespace google_speech_api_trial4
    {
        class Program
        {
            public static string ACCESS_GOOGLE_SPEECH_KEY =     "AIzaSyDC8nM1S0cLpXvRc8TXrDoey-tqQsoBGnM";
    
        static void Main(string[] args)
        {
            GoogleSpeechRequest();
            Console.ReadLine();
        }
                 public static void GoogleSpeechRequest()
        {
                FileStream fileStream = File.OpenRead("my.flac");
            MemoryStream memoryStream = new MemoryStream();
            memoryStream.SetLength(fileStream.Length);
            fileStream.Read(memoryStream.GetBuffer(), 0, (int)fileStream.Length);
            byte[] BA_AudioFile = memoryStream.GetBuffer();
            HttpWebRequest _HWR_SpeechToText = null;
            _HWR_SpeechToText = (HttpWebRequest)HttpWebRequest.Create("https://www.google.com/speech-api/v2/recognize?output=json&lang=en-us&key=" + ACCESS_GOOGLE_SPEECH_KEY);
            _HWR_SpeechToText.Credentials = CredentialCache.DefaultCredentials;
            _HWR_SpeechToText.Method = "POST";
            _HWR_SpeechToText.ContentType = "audio/x-flac; rate=44100";
            _HWR_SpeechToText.ContentLength = BA_AudioFile.Length;
            Stream stream = _HWR_SpeechToText.GetRequestStream();
            stream.Write(BA_AudioFile, 0, BA_AudioFile.Length);
            stream.Close();
            HttpWebResponse HWR_Response = (HttpWebResponse)_HWR_SpeechToText.GetResponse();
            StreamReader SR_Response = new StreamReader(HWR_Response.GetResponseStream());
            string responseFromServer = (SR_Response.ReadToEnd());
            String[] jsons = responseFromServer.Split('\n');
            String text = "";
            foreach (String j in jsons)
            {
                dynamic jsonObject = JsonConvert.DeserializeObject(j);
                if (jsonObject == null || jsonObject.result.Count <= 0)
                {
                    continue;
                }
                text = jsonObject.result[0].alternative[0].transcript;
            }
            Console.WriteLine(text);
        }
        }
    }

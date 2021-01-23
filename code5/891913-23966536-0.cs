    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            Task<FileContentResult> task = Task.Run(() =>
            {
                using (var synth = new SpeechSynthesizer())
                using (var stream = new MemoryStream())
                {
                    synth.SetOutputToWaveStream(stream);
                    synth.Speak("test text to audio!");
                    byte[] bytes = stream.GetBuffer();
                    return File(bytes, "audio/x-wav");
                }
            });
            return await task;
        }
    }

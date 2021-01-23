        [HttpGet]
        public ActionResult GetAudioFile(string fileLocation)
        {
            var bytes = new byte[0];
            using (var fs = new FileStream(fileLocation, FileMode.Open, FileAccess.Read)
            {
                var br = new BinaryReader(fs);
                long numBytes = new FileInfo(fileLocation).Length;
                buff = br.ReadBytes((int)numBytes);
            }
            return File(buff, "audio/mpeg", "callrecording.mp3");
        }

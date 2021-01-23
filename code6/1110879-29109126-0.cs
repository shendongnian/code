    using System;
    using System.IO;
    using System.Linq;
    namespace SoundProvider
    {
        public class SoundPathProvider
        {
            private readonly string _sourcePath;
            public SoundPathProvider(string sourcePath)
            {
                _sourcePath = sourcePath;
            }
            public string GetSoundPath(string soundName)
            {
                var files = Directory.EnumerateFiles(_sourcePath);
                var targetSound = files.FirstOrDefault(x => x.Split('\\').Last() == soundName);
                if (targetSound != null)
                    return Path.Combine(_sourcePath, soundName);
                else 
                    throw new Exception(string.Format("Sound '{0}' Not Found in '{1}'", soundName, _sourcePath));
            }
        }
    }

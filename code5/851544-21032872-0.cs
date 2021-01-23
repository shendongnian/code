    using System.Reflection;
    using System.IO;
    ...
        public static Image LoadPigeon(string name) {
            var exeDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var imgDir = Path.Combine(exeDir, "pigeonImages");
            var imgPath = Path.Combine(imgDir, name);
            return Image.FromFile(imgPath);
        }

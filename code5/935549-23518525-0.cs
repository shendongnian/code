    public class GameImage : Image
    {
        public static GameImage GetImage(string filename)
        {
            GameImage img = (GameImage)Image.FromFile(filename);
            img.FileName = filename;
            return img;
        }
        public string FileName { get; private set; }
    }

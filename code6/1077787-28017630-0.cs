    // using System.Collections.Generic;
    // using System.Linq;
    string imageData = File.ReadAllText(args[0]);
    HashSet<char> whiteSpace = new HashSet<char> { '\t', '\n', '\r', ' ' };
    int length = imageData.Count(c => !whiteSpace.Contains(c));
    if (length % 4 != 0)
        imageData += new string('=', 4 - length % 4); // Pad length to multiple of 4.
    byte[] imageBytes = Convert.FromBase64String(imageData);
    MemoryStream ms = new MemoryStream(imageBytes);
    Image image = Image.FromStream(ms, true);
    image.Save(args[1], System.Drawing.Imaging.ImageFormat.Gif);

        static void Main(string[] args)
        {
            string path = @"C:\image.jpg";
            string[] tagset = new string[] { "tag1", "tag2", "tag3" };
            TagLib.File tagFile = TagLib.File.Create(path);
            var image = tagFile as TagLib.Image.File;
            Console.WriteLine("Rating          : " + image.ImageTag.Rating);
            Console.WriteLine("DateTime        : " + image.ImageTag.DateTime);
            Console.WriteLine("Orientation     : " + image.ImageTag.Orientation);
            Console.WriteLine("Software        : " + image.ImageTag.Software);
            Console.WriteLine("ExposureTime    : " + image.ImageTag.ExposureTime);
            Console.WriteLine("FNumber         : " + image.ImageTag.FNumber);
            Console.WriteLine("ISOSpeedRatings : " + image.ImageTag.ISOSpeedRatings);
            Console.WriteLine("FocalLength     : " + image.ImageTag.FocalLength);
            Console.WriteLine("FocalLength35mm : " + image.ImageTag.FocalLengthIn35mmFilm);
            Console.WriteLine("Make            : " + image.ImageTag.Make);
            Console.WriteLine("Model           : " + image.ImageTag.Model);
            image.ImageTag.Keywords = tagset;
            image.Save();
            foreach (var item in image.ImageTag.Keywords)
                Console.WriteLine("> Tag: " + item);                
            Console.ReadLine();
        }

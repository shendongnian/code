            Image im = Image.FromFile("image file path");
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();            
            var allPoprItem = im.PropertyItems;
            const int metTitle = 0x10e;
            var Title = allPoprItem.FirstOrDefault(x => x.Id == metTitle);
            Console.WriteLine(encoding.GetString(Title.Value));
    

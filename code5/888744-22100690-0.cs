    string path = @"C:\Dev\my-image.jpg";
    var image = Image.FromFile(path);
    var encoding = new System.Text.ASCIIEncoding();
    var make = image.PropertyItems.Single(x => x.Id == 0x010F).Value;
    var model = image.PropertyItems.Single(x => x.Id == 0x0110).Value;
    Console.WriteLine(encoding.GetString(make));
    Console.WriteLine(encoding.GetString(model));

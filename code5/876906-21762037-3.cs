    class Program
    {
        static void Main(string[] args)
        {
            RootObject obj = new RootObject();
            obj.Views = new List<View>
            {
                new View
                {
                    Id = "MAIN_TOP_IMAGE_b",
                    ElementData = new Image
                    {
                        Value = "Base64 encoding(image.jpg)",
                        Type = "jpg;base64",
                        Align = "right"
                    }
                },
                new View
                {
                    Id = "MAIN_BARCODE_a",
                    ElementData = new Barcode
                    {
                        Value = " 32455232453",
                        Type = "QRCODE",
                        Caption = "1432343fdoadkfe"
                    }
                }
            };
            string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            Console.WriteLine(json);
        }
    }

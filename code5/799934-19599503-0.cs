    var src = BitmapImage.Create(
                            500, // set to be big enough so it can be cropped
                            500, // set to be big enough so it can be cropped
                            96,
                            96,
                            System.Windows.Media.PixelFormats.Indexed1,
                            new BitmapPalette(new List<System.Windows.Media.Color> { System.Windows.Media.Colors.Transparent }),
                            new byte[] { 0, 0, 0, 0 },
                            1);

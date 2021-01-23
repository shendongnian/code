            for (var i = 0; i < 30; i++)
            {
                using (var iso = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (var wbBG = BitmapFactory.New(0, 0).FromContent("Assets/image" + i + ".jpg"))
                    {
                        wbBG.Invalidate();
                        for (int j = 0; j < 6; j++)
                        {
                            var tb = new TextBlock()
                            {
                                Text = j.ToString(),
                                //FontSize = 13,
                                //Height = 20,
                                //Width = 240,
                                //FontWeight = System.Windows.FontWeights.Bold,
                                //HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                                //Foreground = new SolidColorBrush(Colors.White)
                            };
                            wbBG.Render(tb, new TranslateTransform() { X = j * 65, Y = 350 });
                            wbBG.Invalidate();
                        }
                        using (var stream = iso.CreateFile("/Shared/" + i + ".jpg"))
                        {
                            wbBG.SaveJpeg(stream, 480, 800, 0, 85);
                        }
                    }
                }
            }

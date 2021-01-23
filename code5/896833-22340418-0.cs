            button.Click += async delegate
            {
                var destination = Path.Combine(
                    System.Environment.GetFolderPath(
                        System.Environment.SpecialFolder.ApplicationData),
                        "music.mp3");
                await new WebClient().DownloadFileTaskAsync(
                    new Uri("http://www.xyz.com/music.mp3"),
                    destination);
            };

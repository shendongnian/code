     string htmlColor = "#f6fe40";
     ApplicationBar.BackgroundColor = Color.FromArgb(255,
                        Convert.ToByte(htmlColor.Substring(1, 2), 16),
                        Convert.ToByte(htmlColor.Substring(3, 2), 16),
                        Convert.ToByte(htmlColor.Substring(5, 2), 16)
                        );

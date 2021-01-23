            ad.ErrorOccurred += (snd, args) =>
            {
                if (ad.Visibility == Visibility.Visible)
                {
                    ad.Visibility = Visibility.Collapsed;
                    AdDuplex.Controls.AdControl adAd = new AdDuplex.Controls.AdControl { AppId = "104211" };
                    adPanel.Children.Insert(0, adAd);
                }
            };

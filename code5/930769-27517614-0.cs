                byte[] bytearray = null;
                using (var ms = new MemoryStream())
                {
                    if (bmp != null)
                    {
                        var wbitmp = new WriteableBitmap(bmp);
                        wbitmp.SaveJpeg(ms, 46, 38, 0, 100);
                        bytearray = ms.ToArray();
                    }
                }
                if (bytearray != null)
                {
                    // image base64 here
                    string btmStr = Convert.ToBase64String(bytearray);
                }

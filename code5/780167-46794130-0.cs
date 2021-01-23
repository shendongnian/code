    RichTextBox rtb = new RichTextBox();    
    byte[] headerImage = (byte[])(dr["ImageData"]);
                    string imageData = string.Empty;
                    if (headerImage != null && headerImage.Length > 0)
                    {
                        Bitmap bmp = new Bitmap(new MemoryStream(headerImage));
                        MemoryStream ms = new MemoryStream();
                        bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        ms.Position = 0;   
                        imageData = @"{\pict\jpegblip\picw10449\pich3280\picwgoal9924\pichgoal1860\ " + BitConverter.ToString(ms.ToArray()).Replace("-", string.Empty).ToLower() + "}";
                        ms.Dispose();
                    }
    string finalrtfdata = rtb.Rtf;
                    finalrtfdata = finalrtfdata.Replace("&ImageHeader&", imageData);
    // finalrtfdata contain your image data along with rtf tags.

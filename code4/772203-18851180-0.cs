     System.Drawing.Image dbImage =
                     System.Drawing.Image.FromFile("file path");
                System.Drawing.Image thumbnailImage =
                     dbImage.GetThumbnailImage(80, 80, null, new System.IntPtr());
                thumbnailImage.Save(mstream, dbImage.RawFormat);
                Byte[] thumbnailByteArray = new Byte[mstream.Length];
                mstream.Position = 0;
                mstream.Read(thumbnailByteArray, 0, Convert.ToInt32(mstream.Length));
                context.Response.Clear();
                context.Response.ContentType = "image/jpeg";
                context.Response.BinaryWrite(thumbnailByteArray);

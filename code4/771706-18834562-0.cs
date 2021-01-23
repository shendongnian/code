                    string path = "Path of image";
                    Bitmap bmp = new Bitmap(path);
                    StringBuilder sb = new StringBuilder();
                    FileInfo fi = new FileInfo(path);
                    sb.AppendLine("Name : " + fi.Name);
                    sb.AppendLine("Width : " + bmp.Width);
                    sb.AppendLine("Height : " + bmp.Height);
                    sb.AppendLine("Horizontal Resolution : " + bmp.HorizontalResolution);
                    sb.AppendLine("Vertical Resolution : " + bmp.VerticalResolution);
                    string type = "";
                    if (fi.Extension == ".bmp")
                    {
                        type = "Bitmap Image";
                    }
                    else if (fi.Extension == ".jpg" || fi.Extension == ".jpeg")
                    {
                        type = "Joint Photographic Experts Group Image File";
                    }
                    else if (fi.Extension == ".png")
                    {
                        type = "Portable Network Graphic Image";
                    }
                    sb.AppendLine("Type : " + type);
                    MessageBox.Show(sb.ToString(), path, MessageBoxButtons.OK, MessageBoxIcon.Information);

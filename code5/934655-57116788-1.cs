    private void  UploadResizeImage()
        {
            string codigo = "";
            string dano = "";
            string nav = "";
            string nombreArchivo = "";
            string extension = "";
            int cont = 0;
            int MaxWidthHeight = 1024; // This is the maximum size that the width or height file should have
            int factorConversion = 0;
            int newWidth = 0;
            int newHeight = 0;
            int porcExcesoImg = 0;
            Bitmap newImage = null;
            string directory = "dano";
            System.Drawing.Image image = null;
            try
            {
                if (!String.IsNullOrEmpty(Request.QueryString["codigo"]) && !String.IsNullOrEmpty(Request.QueryString["dano"]) && !String.IsNullOrEmpty(Request.QueryString["nav"]))
                {
                    codigo = Request.QueryString["codigo"].ToString();
                    dano = Request.QueryString["dano"].ToString();
                    nav = Request.QueryString["nav"].ToString();
                    Directory.CreateDirectory(Server.MapPath(directory));
                    Directory.CreateDirectory(Server.MapPath(directory + "/" + nav));
                    string fechaHora = DateTime.Now.ToString("yyyyMMdd-HHmmss");
                    nombreArchivo = codigo + "-" + dano + "-" + fechaHora;
                    string html = "<h4>Se cargaron con éxito estos archivos al servidor:</h4>";
                    if (UploadImages.HasFiles)
                    {
                        html += "<ul>";
                        foreach (HttpPostedFile uploadedFile in UploadImages.PostedFiles)
                        {
                            cont++;
                            extension = System.IO.Path.GetExtension(UploadImages.FileName);
                            if (extension.ToLower() == ".png" || extension.ToLower() == ".jpg")
                            {
                                Stream strm = null;
                                strm = uploadedFile.InputStream;
                                //strm = UploadImages.PostedFile.InputStream;
                                using (image = System.Drawing.Image.FromStream(strm))
                                {
                                    string size = image.Size.ToString();
                                    int width = image.Width;
                                    int height = image.Height;
                                    if (width > MaxWidthHeight || height > MaxWidthHeight)
                                    {
                                        porcExcesoImg = (width * 100) / MaxWidthHeight; // excessive size in percentage
                                        factorConversion = porcExcesoImg / 100;
                                        newWidth = width / factorConversion;
                                        newHeight = height / factorConversion;
                                        newImage = new Bitmap(newWidth, newHeight);
                                        var graphImage = Graphics.FromImage(newImage);
                                        graphImage.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                                        graphImage.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                                        graphImage.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                                        var imgRectangle = new Rectangle(0, 0, newWidth, newHeight);
                                        graphImage.DrawImage(image, imgRectangle);
                                    }
                                    string targetPath = Server.MapPath("~/" + directory + "/" + nav + "/").ToString() + nombreArchivo + "-" + cont.ToString() + extension;
                                    newImage.Save(targetPath, image.RawFormat);
                                    
                                    html += "<li>" + String.Format("{0}", uploadedFile.FileName) + "</li>";
                                }
                                
                            }
                        }
                        html += "</ul>";
                        listofuploadedfiles.Text = html;
                    }
                    else
                    {
                        listofuploadedfiles.Text = "No se ha selecionado ninguna imagen!";
                    }
                }
                else
                {
                    listofuploadedfiles.Text = "No se recibieron los parámetros para poder cargar las imágenes!";
                }
            }
            catch (Exception ex)
            {
                listofuploadedfiles.Text = ex.Message.ToString();
            }
        }

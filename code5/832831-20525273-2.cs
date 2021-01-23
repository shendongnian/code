     string uploadPath = Server.MapPath("~/Assets/Images/Products/" + productId);
     if (!Directory.Exists(uploadPath))
     {
          Directory.CreateDirectory(uploadPath);
     }
     Dictionary<string, string> versions = new Dictionary<string, string>();
     versions.Add("_m", "width=150&height=150&scale=both&format=jpg");  // Medium size
     string filePrefix = productId + "_" + imageNo;
     versions.Add("_s", "width=90&height=90&scale=both&format=jpg");  // Small size
     versions.Add("_l", "width=300&height=300&scale=both&format=jpg");  // Large size
     foreach (string fileSuffix in versions.Keys)
     {
          // Generate a filename
          string fileName = Path.Combine(uploadPath, filePrefix + fileSuffix);
          // Let the image builder add the correct extension based on the output file type
          fileName = ImageBuilder.Current.Build(imageFile, fileName, new ResizeSettings(versions[fileSuffix]), false, true);
     }

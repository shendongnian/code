      Bitmap newa2 = null;
      using (var a2 = (Bitmap)Image.FromFile(FileName)) {
          newa2 = new Bitmap(a2, new Size(a2.Width * 3 / 2, a2.Height * 3 / 2));
          newa2.SetResolution(1920, 1080);
      }
      newa2.Save(Path.Combine(resizedArchiveFolder, Path.GetFileName(FileName))); 
      return newa2;

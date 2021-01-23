    public bool ScreenCapture(ref Message msg) {
      var WParam = (Keys)msg.WParam;
      if ((WParam == Keys.PrintScreen) || (WParam == (Keys.PrintScreen & Keys.Alt))) {
        ScreenCapture(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
        msg = new Message(); // erases the data
        return true;
      }
      return false;
    }
    public void ScreenCapture(string initialDirectory) {
      this.Refresh();
      var rect = new Rectangle(Location.X, Location.Y, Size.Width, Size.Height);
      var imgFile = Global.ScreenCapture(rect);
      //string fullName = null;
      string filename = null;
      string extension = null;
      if ((imgFile != null) && imgFile.Exists) {
        filename = Global.GetFilenameWithoutExt(imgFile.FullName);
        extension = Path.GetExtension(imgFile.FullName);
      } else {
        using (var worker = new BackgroundWorker()) {
          worker.DoWork += delegate(object sender, DoWorkEventArgs e) {
            Thread.Sleep(300);
            var bmp = new Bitmap(rect.Width, rect.Height);
            using (var g = Graphics.FromImage(bmp)) {
              g.CopyFromScreen(Location, Point.Empty, rect.Size); // WinForm Only
            }
            e.Result = bmp;
          };
          worker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Error != null) {
              var err = e.Error;
              while (err.InnerException != null) {
                err = err.InnerException;
              }
              MessageBox.Show(err.Message, "Screen Capture", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            } else if (e.Cancelled) {
            } else if (e.Result != null) {
              if (e.Result is Bitmap) {
                var bitmap = (Bitmap)e.Result;
                imgFile = new FileInfo(Global.GetUniqueFilenameWithPath(m_screenShotPath, "Screenshot", ".jpg"));
                filename = Global.GetFilenameWithoutExt(imgFile.FullName);
                extension = Path.GetExtension(imgFile.FullName);
                bitmap.Save(imgFile.FullName, ImageFormat.Jpeg);
              }
            }
          };
          worker.RunWorkerAsync();
        }
      }
      if ((imgFile != null) && imgFile.Exists && !String.IsNullOrEmpty(filename) && !String.IsNullOrEmpty(extension)) {
        bool ok = false;
        using (SaveFileDialog dlg = new SaveFileDialog()) {
          dlg.Title = "ACP Image Capture: Image Name, File Format, and Destination";
          dlg.FileName = filename;
          dlg.InitialDirectory = m_screenShotPath;
          dlg.DefaultExt = extension;
          dlg.AddExtension = true;
          dlg.Filter = "PNG Image|*.png|Jpeg Image (JPG)|*.jpg|GIF Image (GIF)|*.gif|Bitmap (BMP)|*.bmp" +
            "|EWM Image|*.emf|TIFF Image|*.tif|Windows Metafile (WMF)|*.wmf|Exchangable image file|*.exif";
          dlg.FilterIndex = 0;
          if (dlg.ShowDialog(this) == DialogResult.OK) {
            imgFile = imgFile.CopyTo(dlg.FileName, true);
            m_screenShotPath = imgFile.DirectoryName;
            ImageFormat fmtStyle;
            switch (dlg.FilterIndex) {
              case 2: fmtStyle = ImageFormat.Jpeg; break;
              case 3: fmtStyle = ImageFormat.Gif; break;
              case 4: fmtStyle = ImageFormat.Bmp; break;
              case 5: fmtStyle = ImageFormat.Emf; break;
              case 6: fmtStyle = ImageFormat.Tiff; break;
              case 7: fmtStyle = ImageFormat.Wmf; break;
              case 8: fmtStyle = ImageFormat.Exif; break;
              default: fmtStyle = ImageFormat.Png; break;
            }
            ok = true;
          }
        }
        if (ok) {
          string command = string.Format(@"{0}", imgFile.FullName);
          try { // try default image viewer
            var psi = new ProcessStartInfo(command);
            Process.Start(psi);
          } catch (Exception) {
            try { // try IE
              ProcessStartInfo psi = new ProcessStartInfo("iexplore.exe", command);
              Process.Start(psi);
            } catch (Exception) { }
          }
        }
      }
    }

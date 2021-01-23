            OpenDialog.AutoUpgradeEnabled = true;
            OpenDialog.CheckFileExists = true;
            OpenDialog.CheckPathExists = true;
            OpenDialog.DefaultExt = "";
            OpenDialog.FileName = "";
            OpenDialog.Filter = "Images (.jpeg)|*.jpg;*.jpeg";
            OpenDialog.InitialDirectory = @"C:\";
            OpenDialog.Multiselect = false;
            OpenDialog.RestoreDirectory = false;
            OpenDialog.ShowHelp = false;
            OpenDialog.ShowReadOnly = false;
            OpenDialog.Title = this.Text;
            if (OpenDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Image productimage = Image.FromFile(OpenDialog.FileName);
                System.Drawing.Size defaultsize = new Size(129, 129);
                if (productimage.Width > defaultsize.Width ||
                    productimage.Height > defaultsize.Height)
                {
                    Common.ShowErrorMessage("Cannot load large image. Default size (128 X 128)", 
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                PicBox.Image = productimage;

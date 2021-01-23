    System.ArgumentException: Parameter is not valid.
       at System.Drawing.Image.get_FrameDimensionsList()
       at System.Drawing.ImageAnimator.CanAnimate(Image image)
       at System.Drawing.ImageAnimator.ImageInfo..ctor(Image image)
       at System.Drawing.ImageAnimator.Animate(Image image, EventHandler onFrameChangedHandler)
       at System.Windows.Forms.PictureBox.Animate(Boolean animate)
       at System.Windows.Forms.PictureBox.Animate()
       at System.Windows.Forms.PictureBox.InstallNewImage(Image value, ImageInstallationType installationType)
       at System.Windows.Forms.PictureBox.set_Image(Image value)
       at xxxxx.BarcodeGenerator.btnStOk_Click(Object sender, EventArgs e) in C:\xxxxx\xxxxx\BarcodeGenerator.cs:line 459

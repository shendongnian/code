    if (errors == 0)
    {
    this.Height = 323;
    goButton.Enabled = false;
    stopButton.Enabled = true;
    Bitmap white = OomTestApp.Properties.Resources.white;
    Bitmap black = OomTestApp.Properties.Resources.black;
    Bitmap bmWatermark = black;
    Bitmap processImage = null;
    progressBar1.Maximum = filesToProcess.Count;
                        
    foreach (string handleFile in filesToProcess)
    {
        string fileName = System.IO.Path.GetFileName(handleFile);
        fileNameLabel.Text = "File: " + System.IO.Path.GetFileName(handleFile);
        try
        {
            // create backup if checked
            if (diOriginal != null)
            {
                System.IO.File.Move(handleFile, System.IO.Path.Combine(diOriginal.FullName, fileName));
                processImage = (Bitmap)Bitmap.FromFile(System.IO.Path.Combine(diOriginal.FullName, fileName));
            }
            else
            {
                processImage = (Bitmap)Bitmap.FromFile(handleFile);
            }
            double aspectRatio = (double)processImage.Width / (double)processImage.Height;
            using (Graphics gWatermark = Graphics.FromImage(processImage))
            {
                gWatermark.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
                // position watermark - watermark should be 10% of the image height
                int watermarkHeight = (int)(processImage.Height * 0.1);
                int watermarkPadding = (int)(watermarkHeight * 0.1); // not completely true, but asume watermark is square
                // calculate rectangle. if there is extra text, add extra padding below
                Rectangle watermarkArea = new Rectangle(watermarkPadding, processImage.Height - (watermarkPadding + (watermarkText.Text.Length == 0 ? 0 : watermarkPadding) + watermarkHeight), watermarkHeight, watermarkHeight);
                // determine color watermark
                bmWatermark = black;
                if (watermarkCombo.SelectedIndex == 0)
                {
                    /*using (Bitmap watermarkClone = processImage.Clone(watermarkArea, processImage.PixelFormat))
                    {*/
                    var pixels = Pixels(processImage);
                    if (pixels.Average((Func<Color, decimal>)Intensity) < 110) // human eye adoption; normal threshold should be 128
                    {
                        bmWatermark = white;
                        drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
                    }
                    //}
                }
                else if (watermarkCombo.SelectedIndex == 1)
                {
                    bmWatermark = white;
                    drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
                }
                // draw the watermark
                gWatermark.DrawImage(bmWatermark, watermarkArea.X, watermarkArea.Y, watermarkArea.Width, watermarkArea.Height);
                // draw the text (if needed)
                if (watermarkText.Text.Length > 0)
                {
                    System.Drawing.Font drawFont = new System.Drawing.Font("Tahoma", (float)watermarkPadding);
                    gWatermark.DrawString(watermarkText.Text, drawFont, drawBrush, watermarkPadding, processImage.Height - (watermarkPadding * 2));
                    drawFont.Dispose();
                }
                // disposing resources
                drawBrush.Dispose();
            }
            // save the watermarked file
            processImage.Save(System.IO.Path.Combine(diWatermarked.FullName, fileName), System.Drawing.Imaging.ImageFormat.Jpeg);
            // stop button pressed?
            Application.DoEvents();
            if (stopProcess) break;
            // update exection progress
            progressBar1.Value++;
            percentLabel.Text = ((int)((progressBar1.Value * 100) / filesToProcess.Count)).ToString() + "%";
            fileCountLabel.Text = "File " + progressBar1.Value.ToString() + "/" + filesToProcess.Count.ToString();
        }
        catch (Exception ex)
        {
            try
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(System.IO.Path.Combine(folderText.Text, "errorlog.txt"), true))
                {
                    sw.WriteLine("File: " + fileName);
                    while (ex != null)
                    {
                        sw.WriteLine("Message: " + ex.Message);
                        sw.WriteLine(ex.StackTrace);
                        sw.WriteLine(ex.Source);
                        ex = ex.InnerException;
                    }
                    sw.WriteLine();
                }
            }
            catch
            {
                // nothing to do - it already failed
            }
            errors++;
        }
        finally
        {
            if (processImage != null) processImage.Dispose();
        }
    }
                        
    // dispose resources
    white.Dispose();
    black.Dispose();
    bmWatermark.Dispose();
                        
                        
    if (!stopProcess)
    {
        // set status to complete
        fileCountLabel.Text = "File " + filesToProcess.Count.ToString() + "/" + filesToProcess.Count.ToString();
        percentLabel.Text = "100%";
        fileNameLabel.Text = "Completed...";
    }
    else
    {
        fileNameLabel.Text = "Aborted...";
    }
    fileNameLabel.Text += errors.ToString() + " error(s) encountered";
    // defaults to screen
    progressBar1.Value = progressBar1.Maximum;
    stopProcess = false;
    goButton.Enabled = true;
    stopButton.Enabled = false;

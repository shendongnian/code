    if (DXTextrureMap != null)
    { 
      DXSprite.Begin(SpriteFlags.None);
      //Transpose player posistion to map position and create the current mini map image
      x = (int)player_X / 4;// +/- 4000 is max player range and  /4 = 1000 = max map range
      z = (int)player_Z / 4;
      mini = new Rectangle(x-78, z-78, 157, 157);
      croppedBitmap = new Bitmap(200, 200);
      using (Graphics grD = Graphics.FromImage(croppedBitmap))
      {
        grD.DrawImage(originalBitmap, new Rectangle(0, 0, 157, 157), mini, GraphicsUnit.Pixel);
      }
      //croppedBitmap = Copy(originalBitmap, mini);
      using (MemoryStream s = new MemoryStream())//s is a MemoryStream
      {
        croppedBitmap.Save(s, System.Drawing.Imaging.ImageFormat.Png);
        s.Seek(0, SeekOrigin.Begin); //must do this, or error is thrown in next line
        currentMinimap = Texture.FromStream(DXDevice, s);
        s.Dispose();
      }
      //croppedImage.Dispose();
      DXSprite.Draw(currentMinimap, new Vector3(100f, 100f, 0f), new Vector3(this.GameWindowRect.Right - 125, this.GameWindowRect.Top + 135, 0f), Color.White);
      DXSprite.End();
      currentMinimap.Dispose();
    }

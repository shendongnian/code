    if (ShowRadar)
    {
      //Center point
      RadarCenter = new Vector2(this.GameWindowRect.Right - 125, this.GameWindowRect.Top + 125 + 25 - 15);
      //If map exists
      if (originalBitmap != null)
      {
        DXSprite.Begin(SpriteFlags.None);
        //Transpose player posistion to map position and create the current mini map image
        //player location range -4000 - 4000, bitmap range 0 - 8000
        x = (int)(Math.Abs(-4000 - player_Z));
        z = (int)(Math.Abs(4000 - player_X));
        //minimap rec loc on bitmap with a scale of 1000x1000
        mini = new Rectangle(x-500, z-500, 1000, 1000);
        croppedBitmap = new Bitmap(200, 200);
        croppedBitmapFinal = new Bitmap(200, 200);
        //draw the crop
        using (Graphics grD = Graphics.FromImage(croppedBitmap))
        {
          grD.DrawImage(originalBitmap, new Rectangle(0, 0, 158, 158), mini, GraphicsUnit.Pixel);
          grD.Dispose();
        }
        //redraw crop as circle
        using (Graphics grD = Graphics.FromImage(croppedBitmapFinal))
        {
          //add circle clip to graphics
          GraphicsPath path = new GraphicsPath();
          path.AddEllipse(0, 0, croppedBitmapFinal.Width-45, croppedBitmapFinal.Height-45);
          grD.SetClip(path);
          //move origin to center for rotate
          float hw = (croppedBitmapFinal.Width / 2)-22.5f;
          float hh = (croppedBitmapFinal.Height / 2)-22.5f;
          grD.TranslateTransform(hw, hh);
          //apply rotate - direction 0 to 3.15 = 0 to 180, -3.15 to 0 = 180 to 360; so multiply by (180/3.15)
          grD.RotateTransform((player_D * 57)-90);
          //Move origin back to original pos
          grD.TranslateTransform(-hw, -hh);
          //Draw to bitmap
          grD.DrawImage(croppedBitmap, 0, 0);
          grD.Dispose();
        }
        //make texture from final bitmap
        using (MemoryStream s = new MemoryStream())//s is a MemoryStream
        {
          croppedBitmapFinal.Save(s, System.Drawing.Imaging.ImageFormat.Png);
          s.Seek(0, SeekOrigin.Begin); //must do this, or error is thrown in next line
          currentMinimap = Texture.FromStream(DXDevice, s);
          s.Dispose();
        }
        //clean up and print to screen
        croppedBitmapFinal.Dispose();
        croppedBitmap.Dispose();
        DXSprite.Draw(currentMinimap, new Vector3(0f, 0f, 0f), new Vector3(this.GameWindowRect.Right - 225, this.GameWindowRect.Top + 35, 0f), Color.White);
        DXSprite.End();
        currentMinimap.Dispose();
      }

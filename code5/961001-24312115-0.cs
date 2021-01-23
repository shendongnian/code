    private void timer1_Tick(object sender, EventArgs e)
    {
          count++;
          string fileName = mainDirectory + count.ToString("D6") + ".jpg";
          sc.CaptureScreenToFile(fileName , System.Drawing.Imaging.ImageFormat.Jpeg);
          sc.CaptureScreen();
          label2.Text = count.ToString();
          if (count == 1)
          {
              label4.Text = string.Format("{0:N2} KB", GetFileSizeOnDisk(fileName).ToString());
              label4.Visible = true;
          }    
          pictureBox1.ImageLocation =  fileName;   
    }
        

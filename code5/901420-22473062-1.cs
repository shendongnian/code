    int counter = 0;
    private void timer1_Tick(object sender, EventArgs e)
    {
        counter =counter+1;
        GetScreenShot(counter);
        email.Send("HAMMAD");
        MessageBox.Show("DONE");
    }
    private static void GetScreenShot(int counter)
    {
        using(Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, 
                                              Screen.PrimaryScreen.Bounds.Height))
       {
          using(Graphics graphics = Graphics.FromImage(bitmap as Image))
          {
             graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);
          }
          bitmap.Save("screenshot"+counter+".jpeg", ImageFormat.Jpeg);       
       }
    }

    public void abStart()
    { 
    try
    {
        AB ab = new AB(wb.getCookies(), side);
        Application.Run(ab); //this is where the exception is thrown
    }
    catch {  }
    }
     try
             {
                 this.Invoke((MethodInvoker)delegate
                 {
                    // handles the code on its own thread
                    if (abON[0] == null || !abON[0].IsAlive)
                   {
                    abON[0] = new Thread(new ThreadStart(abStart));
                    abON[0].SetApartmentState(ApartmentState.STA);
                    abON[0].Start();
                   }
                 });
             }
             catch (Exception ex)
             {
                 MessageBox.Show(""+ex);
             }

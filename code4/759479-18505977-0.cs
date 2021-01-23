    private void rtb_CS_MouseMove(object sender, MouseEventArgs e)
    {
       Thread trd = new Thread(new ParameterizedThreadStart(HandleMouseMove));
       trd.Start(e);
    }  
    private static void HandleMouseMove(object obj)
    {
         // your handle
    }

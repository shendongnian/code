     private void StartKeyBoardProcess(Textbox tb) {
        try {
          if (tb != null) {
              Process.Start("osk.exe", "/C");
              tb.Focus();
            }
        }
        catch (Exception ex) {
          Messagebox.Show("Error: StartKeyBoardProcess: "+ex);
        }
      }
     private void TextBox_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
     {
       Textbox tb = sender as Textbox;
       StartKeyBoardProcess(tb);
     }

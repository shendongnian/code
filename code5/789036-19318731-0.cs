    private void OKBtn_Click(object sender, RoutedEventArgs e)
        {
            Button b = Ctype(sender, Button)
            If(b.Uid = "000") {
               SaveFile;
            }
            Else{
               SaveOtherFile;
             }
        }

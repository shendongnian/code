    private string Arma3Path;
    private void arma2OACheck()
    {
        string path = tb_arma3dir.Text;
        if (path.EndsWith(@"\"))
        Arma3Path = path.TrimEnd('\'') + "\\ArmA2OA.exe";
        if(!File.Exists(Arma3Path))
        {
            a3dir_pic.Source = new BitmapImage(new Uri("./Resources/redX.png", UriKind.Relative));
            a2Good = false;
        }
        else
        {
            a3dir_pic.Source = new BitmapImage(new Uri("./Resources/greenCheck.png", UriKind.Relative));
            a2Good = true;
        }
    }

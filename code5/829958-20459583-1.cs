    var bytes = new byte[] { 226 };
    var s1 = System.Text.Encoding.ASCII.GetString(bytes);//Invalid
    var s2 = System.Text.Encoding.UTF8.GetString(bytes);//Invalid
    var s3 = System.Text.Encoding.GetEncoding("koi8-r").GetString(bytes); //Б
    MessageBox.Show(String.Format("{0} {1} {2}", s1, s2, s3));

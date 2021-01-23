    private void openSlideShowFolder_Click(object sender, EventArgs e)
    {
        if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
        {
        string[] pics1 = Directory.GetFiles(folderBrowserDialog1.SelectedPath, "*.jpg");
        string[] pics2 = Directory.GetFiles(folderBrowserDialog1.SelectedPath, "*.jpeg");
        string[] pics3 = Directory.GetFiles(folderBrowserDialog1.SelectedPath, "*.bmp");
        folderFile = new string[pics1.Length + pics2.Length + pics3.Length];
        Array.Copy(pics1, 0, folderFile, 0, pics1.Length);
        Array.Copy(pics2, 0, folderFile, pics1.Length, pics2.Length);
        Array.Copy(pics3, 0, folderFile, pics1.Length + pics2.Length, pics3.Length);
        selected = 0;
        showImage(folderFile[selected]);
        }
    }

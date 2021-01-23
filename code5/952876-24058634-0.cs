     private async void button1_Click(object sender, EventArgs e)
     {
        progressBar1.Visible = true;
        try
        {
           string result =await ReportGenerator.GenerateLetter();
           MessageBox.Show(result);
           progressBar1.Visible = false;
        }
        catch{
        ........
     }

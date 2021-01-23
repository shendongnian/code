    private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "waiting....";
            Task<string> sCode = Task.Run(async () =>
            {
                string msg =await GenerateCodeAsync();
                return msg;
            });
            label1.Text += sCode.Result;
           
        }
        private Task<string> GenerateCodeAsync()
        {
            return Task.Run<string>(() => GenerateCode());
        }
        private string GenerateCode()
        {
            Thread.Sleep(2000);
            return "I m back" ;
        }

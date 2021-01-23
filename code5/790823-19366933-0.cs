    private void button1_Click(object sender, EventArgs e)
        {
            var request = System.Net.WebRequest.Create("http://ap.hbwd.in/item/2812748393") as System.Net.HttpWebRequest;
            request.Method = "GET";
            request.ContentLength = 0;
            string responseContent;
            using (var response = request.GetResponse() as System.Net.HttpWebResponse)
            {
                using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
                {
                    responseContent = reader.ReadToEnd();
                    textBox1.Text = responseContent;
                }
            }//end

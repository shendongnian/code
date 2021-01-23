    protected void btnSend_Click(object sender, EventArgs e)
         {
                string input = "It's going to be a fine day";
                string[] words = input.Split(' ');
                StringBuilder sb = new StringBuilder();
                foreach (string word in words)
                {
                    if (!string.IsNullOrEmpty(word))
                    {
                        sb.Append("\"");
                        sb.Append(word);
                        sb.Append("\"");
                    }
                }
              lblText.Text = sb.ToString();
      }
  

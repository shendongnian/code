    private void Splitter(string str)
        {
            
            StringBuilder build = new StringBuilder(); //it's more efficent for appending strings in a loop
            string [] words = str.Split(new string[] { @"\r\n" }, StringSplitOptions.None);
            
            int length=words.Length;
            int half = length / 2;
            
            //Appending first half
            for (int i = 0; i < half; i++)
            {
                build.Append(words[i]+"\r\n"); //reintroducing the \r\n because I need 
                                        //to put a System.Enviornment.NewLine in place
                                        //(and the Split method eliminates it)
            }
            txtTextBlock1.Text = build.ToString();
            build.Clear();
            //Appending second half
            for (int i = half; i < length; i++)
            {
                build.Append(words[i] + "\r\n");
            }
            txtTextBlock2.Text = build.ToString();
           
        }

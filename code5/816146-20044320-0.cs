            string x = richTextBox1.Text;
            string result = "";
            for (int i = 0; i < x.Length; i++)
            {
                char c = x[i];
                if (c % 2 == 0)
                {
                    c--;
                }
                else
                {
                    c++;
                }
                result += c;
            }
            richTextBox2.Text=result;

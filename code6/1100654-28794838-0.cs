      private void textBox1_TextChanged(object sender, EventArgs e)
      {
         string input = textBox1.Text;
         // did I cause this event to fire? if not, parse the input
         if (input.LastIndexOf("|") < input.Length - 2)
         {
            input = input.Replace("|", "");
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
               stringBuilder.Append(input[i]);
               if (i % 2 == 1)
               {
                  stringBuilder.Append("|");
               }
            }
            textBox1.Text = stringBuilder.ToString();
            textBox1.Select(textBox1.Text.Length, 0);
         }
      }

    var builder = new StringBuilder();
            var stingParts = richTextBox1.Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < stingParts.Length; i++)
            {
                builder.Append(stingParts[i]);
                builder.Append(string.Format(" --[[{0}{1}]] ", random.Next(), textBox1.Text)));
            }
            var output = builder.ToString();

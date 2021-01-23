            List<string> rt = new List<string>();
            string content = richTextBox.Text;
            foreach (string line in content.Split('\n'))
            {
                if (String.IsNullOrWhiteSpace(line))  //checks if the line is empty
                    continue;
                rt.Add(line);
                rt.Add("\r\n");  //makes a new line
                rt.Add("\r\n");   // makes another new line
            }

            //generate matrix
            StringBuilder sb = new StringBuilder();
            int t = rich_doc.Length; //no. of docs
            int word_count = words.Count;
            richTextBox1.Text = "Doc";
            foreach (word_list w in words)
            {
                sb.Append("\t");
                sb.Append(w.word);
            }
            sb.AppendLine();
            //This loop is not slow anymore :)
            for (int i = 0; i < t; i++) //traverse through number of docs
            {
                sb.Append(i + 1);
                for (int h = 0; h < word_count; h++)//traverse through each distinct word in the list
                {
                    if (words[h].doc[i])
                        sb.Append("\t1");
                    else
                        sb.Append("\t0");
                }
                sb.AppendLine();
            }
            richTextBox1.Text = sb.ToString();

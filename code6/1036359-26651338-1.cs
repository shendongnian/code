            StringBuilder final = new StringBuilder();
            foreach (string split in Label1.Text.Split(' '))
            {
                if (Regex.Match(split, "[a-zA-Z]+").Value.Equals("cigarettes", StringComparison.CurrentCultureIgnoreCase))
                {
                    final.Append(@"<span style='color: red;'>");
                    final.Append(split);
                    final.Append(@"</span>");
                }
                else
                {
                    final.Append(split);
                }
                final.Append(' ');
            }
            Label1.Text = final.ToString().Trim();

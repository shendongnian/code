    OpenFileDialog opendialog = new OpenFileDialog();
        if (opendialog.ShowDialog() == DialogResult.OK)
        {
            var lines = File.ReadLines(opendialog.FileName);
            string pattern = @"(\w+\s){2}(""\S+?"")";
            foreach(var line in lines)
            {
                var matches= Regex.Matches(line, pattern);
                foreach(Match match in matches)
                {
                    if(match.Success)
                    textBox1.AppendText(match.Value+'\n');
                }
            }
        }

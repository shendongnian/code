    DialogResult result = open_dialog.ShowDialog();
    if (result == DialogResult.OK) {
        StreamReader sr = new StreamReader(open_dialog.FileName);
        StringBuilder() sb = new StringBuilder();
        // Don't set the rich_words.Text = data here because there's no need to.
        string line;
        using (var file = File.OpenText(dialog.FileName)) {
            while ((line == file.ReadLine()) != null) {
                if (!line.Contains('\t')) {
                    sb.AppendLine(line);
                }
                // No need to have an else since we only want to do stuff when the line does not contain a tab.
            }
        }
        // Now that you have all of the text from the file into your StringBuilder, you add it as the text in the box.
        rickbox.Text = sb.ToString();
    }

    string badWordsFilePath = openFileDialog2.FileName.ToString();
    string line;
    using (StreamReader sr = new StreamReader(badWordsFilePath)) {}
      line = sr.ReadToEnd();
    }
    badWords = line.Split(new string[]{ Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
    int test = badWords.Length;
    MessageBox.Show("Words have been imported!");
    BadWordsImported = true;

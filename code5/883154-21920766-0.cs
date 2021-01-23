    private void sottolinea_errori_Click(object sender, EventArgs e)
    {
            // Get all the lines in the rich text box
            string[] textBoxLines = this.TextBox_stampa_contenuto.Lines;
            // Check that there is some text
            if (this.TextBox_stampa_contenuto.Text != string.Empty)
            {
                // Create a regual expession match
                Regex rgx = new Regex(@"\d");
                // Create a new dictionary to hold all the words
                Dictionary<string, int> wordDictionary = new Dictionary<string, int>();
                // Path to the list of words
                const string WordListPath = @"WordList.txt";
                // Open the file and read all the words
                StreamReader file = new StreamReader(WordListPath);
                // Read each file into the dictionary
                int i = 0;
                while (!file.EndOfStream)
                {
                    // Read each word, one word per line
                    string line = file.ReadLine();
                    // Check if the line is empty or null and not in the dictionary
                    if (!string.IsNullOrEmpty(line) && !wordDictionary.ContainsKey(line))
                    {
                        // Add the word to the dictionary for easy lookup add the word to lower case
                        wordDictionary.Add(line.ToLower(), i);
                        // Incrament the counter
                        i++;
                    }
                }
                // Close the file
                file.Close();
                // For each line in the text box loop over the logic
                foreach (string textLine in textBoxLines)
                {
                    // Split the text line so we can induvidual words, remove empty entries and trim all the words
                    string[] words = textLine.Split(new char[] { ' ', ',', '.', ':', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(p => p.Trim().ToLower()).ToArray();
                    // For each word
                    foreach (string word in words)
                    {
                        // Check that the word is not a digig
                        if (!rgx.IsMatch(word))
                        {
                            // Check if the word is found, returns true if found
                            if (!wordDictionary.ContainsKey(word))
                            {
                                // Initalize the text modification variables
                                int wordStartPosition, seachIndex = 0;
                                // Find all instances of the current word
                                while ((wordStartPosition = this.TextBox_stampa_contenuto.Text.IndexOf(word, seachIndex, StringComparison.InvariantCultureIgnoreCase)) != -1)
                                {
                                    // Set the word in the text box
                                    this.TextBox_stampa_contenuto.Select(wordStartPosition, word.Length);
                                    // Increase the search index after the word
                                    seachIndex = wordStartPosition + word.Length;
                                    // Set the selection at the begining of the word
                                    this.TextBox_stampa_contenuto.SelectionStart = wordStartPosition;
                                    // Set the lengh for the word lenght
                                    this.TextBox_stampa_contenuto.SelectionLength = word.Length;
                                    // Set the selection color
                                    this.TextBox_stampa_contenuto.SelectionColor = Color.Red;
                                }
                            }
                        }
                    }
                }
            }
    }

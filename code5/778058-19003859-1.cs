    private async void startSearchBtn_Click(object sender, EventArgs e)
    {
        await Search(files, selectTxcDirectory.SelectedPath, status, SearchCompleted); // <-- pass the callback method here
    }
    private static async Task Search(List<string> files, string path, Label statusText, Action<string> callback)
    {
        foreach (string file in files)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(file);
            statusText.Text = "Started scanning...";
            using (XmlReader reader = XmlReader.Create(new StringReader(xmlDoc.InnerXml), new XmlReaderSettings() { Async = true }))
            {
                while (await reader.ReadAsync())
                {
                    if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "LineName"))
                    {
                        Console.WriteLine(reader.ReadInnerXml());
                    }
                }
            }
            // Here you're done with the file so invoke the callback that's it.
            callback(file); // pass which file is finished
        }
    }
    private static void SearchCompleted(string file)
    {
        // This method will be called whenever a file is processed.
    }

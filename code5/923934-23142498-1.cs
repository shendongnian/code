    public static void DeSerializationXML(string path)
    {
         ...
         TextReader txtReader = new StreamReader(path);
    }
    private void ChangeLotFilePath()
    {
        using (var dialog = new OpenFileDialog()) {
            dialog.Filter = "XML files (*.xml) | *.xml";
            if (dialog.ShowDialog() == DialogResult.OK) {
                DeserializationXML(dialog.FileName);
            }
        }
    }

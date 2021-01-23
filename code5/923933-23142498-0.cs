    public static void DeSerializationXML(string path)
    {
         ...
         TextReader txtReader = new StreamReader(path);
    }
    private void ChangeLotFilePath()
    {
        OpenFileDialog Dialog = new OpenFileDialog();
        Dialog.Filter = "XML files (*.xml)|*.xml";
        Dialog.ShowDialog();
        if (!String.IsNullOrEmpty(Dialog.FileName))
        {
            DeSerializationXML(Dialog.FileName);
        }
    }

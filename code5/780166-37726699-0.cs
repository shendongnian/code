    private static void createImage(RichTextBox item)
    {
      var image = new Hashtable(1) { { item, Properties.Resources.yourimage } };
      Clipboard.SetImage((Image)image[item]);
      item.Paste();
    }

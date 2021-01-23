    public class MyWordGame {
       public string[] myWords;
       public int height;
       ...
    }
    ...
    XmlSerializer xmlOut = new XmlSerializer(MyWordGame.GetType());
    xmlOut.Serialize(new FileStream(mySaveFileDialog.Filename), new MyWordGame());

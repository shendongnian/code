    [Serializable]
    class MyClass
    {
      int type;
      [NonSerialized]
      List<FileStream> listfile;
      string content_text;
      public MyClass(int t)
      {
        type = t;
      }
      public MyClass()
      {
        type = 0;
      }
    }

    public class MyObject
    {
      string varName = "myObject";
      public MyObject()
      {
        string js = "var " + varName + " = new ActiveXObject(\"TestLib.MyObject\");"
        HtmlPage.Window.Eval(js);
      }
      public int Add(int x, int y)
      {
        string js = string.Format("{0}.Add({1},{3});", varName, x, y);
        return (int)HtmlPage.Window.Eval(js);
      }
    }

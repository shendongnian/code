    public partial class Default2 : System.Web.UI.Page
    {
      protected void Button1_Click(object sender, EventArgs e)
      {
          string[] arr = { "func1", "func2" };
          System.Reflection.MethodInfo methodInfo = typeof(Default2).GetMethod(arr[0]);
          if (methodInfo != null)
          {
              methodInfo.Invoke(this, null);
          }
      }
      public void func1()
      {
          Response.Write("func1");
      }
      public void func2()
      {
          Response.Write("func1");
      }
    }

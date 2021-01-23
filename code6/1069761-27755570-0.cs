      namespace Test
      {
          public static class PrimeTool
          {
              public static bool IsPrime(int candidate)
              {
                  // Test whether the parameter is a prime number.
                  if ((candidate & 1) == 0)
                  {
                      if (candidate == 2)
                      {
                          return true;
                      }
                      else
                      {
                          return false;
                      }
                  }
                  for (int i = 3;
                      (i * i) <= candidate; i += 2)
                  {
                      if ((candidate % i) == 0)
                      {
                          return false;
                      }
                  }
                  return candidate != 1;
              }
          }
          public partial class TestWebForm: System.Web.UI.Page
          {
              protected void Page_Load(object sender, EventArgs e)
              {
              }
              protected void Button1_Click(object sender, EventArgs e)
              {
                  bool prime = PrimeTool.IsPrime(7); //when a class is static  , you don't `new()` it.
                  Response.Write("7 is prime=" + prime)
              }
          }
      }

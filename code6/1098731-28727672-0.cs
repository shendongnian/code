    using System;
    using System.Web.Services;
    public class DEMOAddNumbers : WebService
    {
      [WebMethod]
      public int AddThis(int x, int y)
      {
        int mySum;
        mySum = x + y;
        return mySum;
      }

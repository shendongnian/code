    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    public class test {
      public static void Main(string[] args)
      {
        //List<int> listColumns = new List<int>(){ 1, 5, 6, 9};
        System.Collections.Generic.List<int> listColumns = new System.Collections.Generic.List<int>(){ 1, 5, 6, 9};
        string s = String.Join(", ", listColumns.Select(x => x.ToString()));
        string sql = String.Format("SELECT * FROM Table WHERE ID IN ({0})", s);
        Console.WriteLine(sql);
      }
    }

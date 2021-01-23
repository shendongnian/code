     using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;
        using System.Web.Script.Serialization;
    
        namespace ConsoleApplication1
        {
           public class Program
           {
              static void Main(string[] args)
              {
                  object newobj = new object();
    
                  for (int i = 0; i < 10; i++)
                  {
                    List<int> temp = new List<int>();
    
                    temp.Add(i);
                    temp.Add(i + 1);
    
                     newobj = newobj.AddNewField("item_" + i.ToString(), temp.ToArray());
                  }
    
             }
    
         }
    
          public static class DynamicExtention
          {
              public static object AddNewField(this object obj, string key, object value)
              {
                  JavaScriptSerializer js = new JavaScriptSerializer();
    
                  string data = js.Serialize(obj);
     
                  string newPrametr = "\"" + key + "\":" + js.Serialize(value);
    
                  if (data.Length == 2)
                 {
                     data = data.Insert(1, newPrametr);
                  }
                else
                  {
                      data = data.Insert(data.Length-1, ","+newPrametr);
                  }
    
                  return js.DeserializeObject(data);
              }
          }
       }

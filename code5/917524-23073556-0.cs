       public void FindAndRender(object obj, TextWriter writer)
       {
               if (obj == null)
               {
                       writer.Write(SystemInfo.NullText);          // <=== here!!!
               }
               else
               {
                       // etc..
               }
       }

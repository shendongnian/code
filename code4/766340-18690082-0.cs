             Arry[] arry= new Arry[dict.Count];
             dict.Values.CopyTo(arry, 0);
             var sBuilder = new StringBuilder();
             Foreach(var val in arry)
             {
               sBuilder.AppendLine(val)
             }
              System.IO.StreamWriter file = new System.IO.StreamWriter("\myfile.buf");
              file.WriteLine(sBuilder);

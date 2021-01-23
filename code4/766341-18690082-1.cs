             Array[] array= new Array[dict.Count];
             dict.Values.CopyTo(array, 0);
             var sBuilder = new StringBuilder();
             Foreach(var value in array)
             {
               sBuilder.AppendLine(value)
             }
              System.IO.StreamWriter file = new System.IO.StreamWriter("\myfile.buf");
              file.WriteLine(sBuilder);

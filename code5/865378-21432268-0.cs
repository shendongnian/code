    StringBuilder sb = new StringBuilder();
    var type = typeof (MyMath);
    sb.AppendFormat("Class Name: {0}", type.Name);
    sb.AppendLine();
    sb.Append("Methods: ");
    sb.AppendLine();
    foreach (var method in type.GetMethods())
    {
         sb.AppendFormat("{0} {1}.{2}( ", method.ReturnType.Name, type.Name, method.Name);
         foreach (var param in method.GetParameters())
         {
             sb.AppendFormat("{0} {1},", param.GetType().Name, param.Name);
         }
         sb.Remove(sb.ToString().Length - 1, 1);
         sb.Append(")");
         sb.AppendLine();
    }
     var content = sb.ToString();
     File.WriteAllText("deneme.txt",content);

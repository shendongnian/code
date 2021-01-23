    ResultBuilder.AppendLine(String.Format("Missing Id's from File 1 are:" )
    for (int i = 0; i < idCheck.Length; i++)
     {
       idCheck[0] = true;
       if (idCheck[i] == false)
        {
          ResultBuilder.Append(String.Format("{0}", i));
        }
    }

    for (i = ROW LOOP)
    {
       for (j = COL LOOP)
       {
          if (ISIMAGE)
          {
             ImageArray.ADD(new imageData(i,j,ImageLoc))
          }
          else
          {
             data[i,j] = "Test";
          }
       }
    }
    writeRange.Value2 = data;
    foreach (imageData iData in ImageArray)
    {
       //Parse the object and load the picture to the right row/col
    }

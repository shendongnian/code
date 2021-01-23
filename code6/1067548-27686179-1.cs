    double temp;
    for (int i = 0; i < n; i++)
    {
       if(double.TryParse(textBoxes[i].Text, out temp)
           values[i] = temp;
       else
       {
           // Not a double value....
           // A message to your user ?
           // fill the array with 0 ?
           // Your choice....
       }
   }

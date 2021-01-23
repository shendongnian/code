    for(int i=0; i<ingredients.Count;i++)
    {
       writer.Write(ingredients[i] + ",");
       writer.Write(newAmounts[i] + ",");
       writer.Write(units[i] + "\n");
     }

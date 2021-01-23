    for (int i = 0; i < line_split.Length; i++)
    {
       for(var j = 0; j < 120; j++)
       {
          if(line_split[i].Contains(@"(" + j + ")\% Processor Time"))
          {
             p.percore[j] = i;
          }
       }
    ...

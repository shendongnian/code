    if (model.FilterSet.Dispositions != null)
         {
             List<int> dispoFilters = new List<int>();
             for (int i = 0; i < model.FilterSet.Dispositions.Count; i++)
             {
                 dispoFilters.Add((int)((RespondentStatus)Enum.Parse(typeof(RespondentStatus), model.FilterSet.Dispositions[i].ToString())));
             }
            //With in the if condition outside the loop you can still access dispoFilters 
         }

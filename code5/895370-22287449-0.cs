    var data = "word 7, word 8, word 9, word 14";
    
    // split the data into word and number
    var dataCollection = data.Split(',').Select (d => new 
    { 
        word = d.Trim().Split(' ')[0], 
        number = int.Parse(d.Trim().Split(' ')[1]) 
    }).ToList();
    
    // store each set of consective results into a collection
    List<string> resultsCollection = new List<string>();
    var sb = new StringBuilder();
    int i = 0;
    while(i < dataCollection.Count ())
    {
        if(i > 0)
        {
           if(dataCollection[i].number == dataCollection[i-1].number + 1)
           {
               if(sb.Length > 0) sb.Append(", ");
           }
           else
           {
              resultsCollection.Add(sb.ToString());
              sb.Clear();
           }
        }
        sb.AppendFormat("{0} {1}", dataCollection[i].word, dataCollection[i].number);
        i++;
    }
    resultsCollection.Add(sb.ToString());

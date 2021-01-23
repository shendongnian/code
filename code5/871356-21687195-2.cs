    //Part 2
    bool wordMatch = data.Count == data2.Count; //quick initial check;
    //you can check for wordMatch == false and return immediately
    
    wordsList.Sort(); //sorting in lexicographical order so will be easy to compare
    wordsList2.Sort(); //this is a 2nd word document
    for (int i = 0; i < data.Count; i++)
    {
           if (data.ElementAt(i) != data2.ElementAt(i))
           {
               wordMatch = false;
               break;
           }
    }

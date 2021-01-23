        if (!foundFolders.Contains(xelem))
        {
           list[i].DescendantsAndSelf().Last().Add(file);
           xelem.Add(list[i]);// <-- here is the problem
        }
        else if (i == list.Length-1)
        {
           xelem.Add(file); //<-- here is the problem 
        }

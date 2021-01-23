    foreach (var v in temp_list)
    {
        // Here I want to iterate through the list in each v
        //casting to IEnumerable will let you iterate
        IEnumerable list = v as IEnumerable;
        //check if successful
        if(list != null)
        {
            foreach (var w in list)
            {
               //your logic
            }
        }
        else
        {
            //else part if needed
        }
    }

    string item1 = null, item2 = null,myValue = "";
    foreach(var item in myCollection)
    {
        if(item.Id == 20)
        {
            item1 = item.Value;
        }
        else if(item.Id == 21)
        {
            item2 = item.Value;
        }
    
        if(item.Id != 20 && item.Id != 21)
        {
            //adding
        }
        else
        {
            if(item.Id !=null)
            {
                myValue = myValue + item1 + item2;
                
            }
        }
    } 

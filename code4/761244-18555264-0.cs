    public void DeleteMember(string p)
        {
    
            if (ML != null)
            {
                Person[] tempList = new Person[ML.Length - 1];
                bool deletedAPerson = false;
                int i = 0;
                foreach (Person pers in ML)
                {
                      
                    if (pers.Name.ToLower().CompareTo(p.ToLower()) == 0)
                    {
                       deletedAPerson = true;
                       continue; //skip over this person and do not copy over to the new Array
                    }
                    
                    if(i < pers.Length) //if no person was found, prevent index out of bounds exception
                        tempList[i++] = pers;
                }
                if(deletedAPerson)
                   ML = tempList;
            }
    
            else Console.WriteLine("Then list is empty.");
        }

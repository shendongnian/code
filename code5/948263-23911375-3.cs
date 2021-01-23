     //loop dict backwards so we can remove items
     for (int i = dict.Count - 1; i >= 0; i--)
            {
                //convert the value to List<>
                List<TestObjs> objs = dict.ElementAt(i).Value as List<TestObjs>;
                //Loop List<> backwards so we can remove items
                for (int j = objs.Count - 1; j >= 0; j--)
                {
                    //if current id in list is value, remove it
                    if (objs[j].id.Equals(1))
                    {
                        objs.RemoveAt(j);
                    }
                }
                //if list is now empty remove dict entry
                if (objs.Count.Equals(0))
                {
                    //use linq to grab the element at index and pass it's key to Remove
                    dict.Remove(dict.ElementAt(i).Key);
                }
            }

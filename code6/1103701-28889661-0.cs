     string[] folderArray = { "1 - Name", "4 - Another name", "3 - Another name" };
                var listId = new List<int>();
                foreach (var item in folderArray)
                {
                    var tempId = 0;
                    if (int.TryParse(item.Split('-')[0].Trim(), out tempId))
                        listId.Add(tempId);
                }
                listId.Sort();
                for (var i=1 ;i<listId.Count ;i++)
                {
                    if(listId[i]-listId[i-1]>1)
                    {
                        Console.WriteLine(listId[i-1]+1);
                        break;
                    }
                }

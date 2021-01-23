        else
        {
            var paramsList = new Dictionary<string,string>(); 
            foreach (var pair in InnerJoinParam)
            {
                paramsList.Add(pair.itemB.Key, pair.itemB.Value);
            }
            parametrsAll.Clear();
            parametrsAll = paramsList;
        }

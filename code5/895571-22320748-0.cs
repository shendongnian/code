    public T Dequeue()
        {
            var highestPriorityList = dictionary[dictionary.Keys.First()];
            if (highestPriorityList.Count == 0)
            {
                dictionary.Remove(dictionary.Keys.First());
            }
            var topElement = highestPriorityList.First();
            highestPriorityList.Remove(topElement);
            return topElement;
        }

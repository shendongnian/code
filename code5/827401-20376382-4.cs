        public async Task<int> LoadData(int distance)
        {
            int count = 0;
            IList<object> dataList = null;
            while (count < 20)
            {
                dataList = await Task.Run(() => _dataService.GetListAsync(distance));
                count = dataList.Count;
                var newItems = dataList.Except(ListOnUI).ToList();
                var removedItems = ListOnUI.Except(dataList).ToList();                
                removedItems.ForEach(x => ListOnUI.Remove(x));
                newItems.ForEach(ListOnUI.Add);
            }
            return count;
        }

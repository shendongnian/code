        private async void LoadCollections()
        {
   
            await Task.Run(() => CallDB());
            Task[] tasks = new Task[1]
            {
                _myList1 = GetDataFromMetaData1(),
                _myList2 = GetDataFromMetaData2()
            };
            await Task.WhenAll(tasks); 
       
            LoadTemplates(); //execute only after 'db_task' completes execution
        }

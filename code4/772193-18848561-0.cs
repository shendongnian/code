                List<int[]> myList = new List<int[]>();
            myList.Add(new int[] { 2, 1 });
            myList.Add(new int[] { 3, 1 }); //Notice - same "PARENT"
            myList.Add(new int[] { 4, 1 }); //Notice - same "PARENT"
            myList.Add(new int[] { 3, 1 }); 
            List<int[]> myValues = new List<int[]>();
            myValues.Add(new int[] { 2, 1 , 1});
            myValues.Add(new int[] { 3, 1 , 2}); //Notice - same "PARENT"
            myValues.Add(new int[] { 4, 1 , 3}); //Notice - same "PARENT"
            myValues.Add(new int[] { 3, 1, 4 });
            myValues.Add(new int[] { 3, 2, 4 }); 
            var q2 = from value in myValues where myList.Select(x => new { ID = x.ElementAt(0), Parent = x.ElementAt(1) }).Contains(new { ID = value.ElementAt(0), Parent = value.ElementAt(1) }) select value;
            var list = q2.ToList();

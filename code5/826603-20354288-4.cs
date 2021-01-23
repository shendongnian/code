     var list = new People
            {
                PersonList = new object[]
                {
                  new object[]
                 {
                   "Test1", "Test2", "Test3", null, new Person{Name="John", Age=21}, 1
                 },
                  new object[]
                 {
                   "Test4", "Test5", "Test6", null, null, 2
                 },
                 new object[]
                 {
                   "Test17", "Test8", "Test9", null, new Person{Name="Sara", Age=31}, 3
                 },
                    new object[]
                 {
                   "Test10", "Test11", "Test12", null, null, 4
                 },
                 new object[]
                 {
                     "Test13", "Test14", "Test15", null, new Person{Name="John", Age=31}, 5
                 }
                 }
               
            };
             string output = JsonConvert.SerializeObject(list);
            var objList = JsonConvert.DeserializeObject<People>(output);
            objectList = objList.PersonList;
            foreach(JArray objectItem in objectList)
            {
                
                var stringOne = (string)objectItem[0];
                var stringTwo = (string)objectItem[1];
                var stringthree = (string)objectItem[2];
                var stringFour = (string)objectItem[3];
                
                JObject obj = (JObject)JToken.FromObject(objectItem[4]);
                var l = obj.ToObject<Person>();
                string name = l.Name;
                int age = l.Age;
                
                var num = (int)objectItem[5];
            }

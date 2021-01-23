                        List<ILoad> list = new List<ILoad>();
            var s = new A();
            list.Add(new A() { PropA = "test1" });
            list.Add(new B() { PropB = "test2" });
            list.Add(new A() { PropA = "test3" });
            foreach (var item in list)
            {
                item.ConvertToMeasure();
            }

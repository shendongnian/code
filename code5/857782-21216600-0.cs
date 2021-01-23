            List<MyOwnList> mylist = new List<MyOwnList>();
            mylist.Add(new MyOwnList { Name = "Name0", Class = "Class0" });
            mylist.Add(new MyOwnList { Name = "Name1", Class = "Class1" });
            mylist.Add(new MyOwnList { Name = "Name2", Class = "Class2" });
            mylist.Add(new MyOwnList { Name = "Name3", Class = "Class3" });
            mylist.Add(new MyOwnList { Name = "Name4", Class = "Class4" });
            mylist[0].Name = "Name0";
            mylist[0].Class = "Class0";
            mylist[1].Name = "Name1";
            mylist[1].Class = "Class1";
            mylist[2].Name = "Name2";
            mylist[2].Class = "Class2";
            mylist[3].Name = "Name3";
            mylist[3].Class = "Class3";
            mylist[4].Name = "Name4";
            mylist[4].Class = "Class4";
            int count = mylist.Count;
            for (int i = count - 1; i >= 0; i--)
            {
                
                if (i > 2)
                {
                    mylist.RemoveAt(i);
                    //mylist[i] = null;
                }
            }
            Console.WriteLine(mylist.Count);

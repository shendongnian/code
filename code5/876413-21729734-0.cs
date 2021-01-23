     private List<BaseObject> GetList()
                {
                    List<ObjectA> aList = MyData.ObjectA.FindAll(delegate(ObjectA my) { return my.ObjectAName == "Harold"; });
                    List<BaseObject> baseList = new List<BaseObject>();
                    //foreach (ObjectA obj in aList)
                    //{
                    //    baseList.Add(obj);
                    //}
                    baseList.AddRange(aList);
                    return baseList;
                }

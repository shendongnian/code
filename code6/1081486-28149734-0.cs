    List<Type2> list2 = (from r in list1
                        group r by new
                        {
                             r.Prop1,
                             r.Prop2,
                             r.Prop3
                        }
                        into groupedRequest
                        let p1 = groupedRequest.Key.Prop1
                        let p2 = GetProp2FromComplexOperation(groupedRequest.Key.Prop1)
                         select new Type2()
                         {
                             Prop1 = p1,
                             Prop2 = p2,
                             Prop3 = p1 + p2
                         }).ToList<Type2>();

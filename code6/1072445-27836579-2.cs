          string[] yourArray = new string[] { "someData.childData.child1", "someData.childData.child2" };
            System.Collections.Generic.List<dynamic> CreatedAll = new System.Collections.Generic.List<dynamic>();
            for (int i = 0; i < yourArray.Length; i++)
            {
                string objStr = yourArray[i];
                string[] objs = objStr.Split('.');
                System.Collections.Generic.List<dynamic> created = new System.Collections.Generic.List<dynamic>();
                for (int j = 0; j < objs.Length; i++)
                {
                    var myObj = System.Activator.CreateInstance("namespaceName", objs[j]);
                    created.Add(myObj);
                }
                System.Reflection.PropertyInfo propertyInfo = created[1].GetType().GetProperty(objs[2]);
                propertyInfo.SetValue(created[1], created[2], null);
                System.Reflection.PropertyInfo propertyInfo1 = created[0].GetType().GetProperty(objs[1]);
                propertyInfo1.SetValue(created[0], created[1], null);
                CreatedAll.Add(created);
            }

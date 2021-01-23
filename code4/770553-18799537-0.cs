       for (int m = 0; m < 10; m++)
            {
                XmlAttributeCollection coll = nodeList.Item(m).Attributes;
                string value = coll.Item(m).Value;
                string value1 = nodeList[m].Attributes["TestCondition"].Value;
                foreach (string attr in value1.Split(','))
                {
                    string attributelowercase = attr.ToLower();
                    Debug.WriteLine(attributelowercase);
                }
            }

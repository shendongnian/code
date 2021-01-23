    Type type = typeof(VSM_Data);
                foreach (var property in type.GetFields())
                {
                    FieldInfo[] children = type.GetFields();
                    for (int i = 0; i < children.Length; i++)
                    {
                        Type child = property.FieldType;
                        var columnnamesChild = from t in child.GetFields() select t.Name;
                        foreach (var item in columnnamesChild)
                        {
                            DragAndDrop FundDragAndDrop = new DragAndDrop();
                            FundDragAndDrop.TITLE = item;
                            FundDragAndDrop.adresse = "{{PERSON." + children[i].Name.ToUpper() + "." + item.ToUpper() + "}}";
                            FundList.Add(FundDragAndDrop);
                        }
                    }
                }

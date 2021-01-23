    private void btnTest_Click(object sender, EventArgs e)
            {
                
               var t = typeof (TestingEnums);
            var nestedTypes = t.GetMembers().Where(item=>item.MemberType == MemberTypes.NestedType);
            foreach (var item in nestedTypes)
            {
                    var type = Type.GetType(item.ToString());
                    if (type!=null && type.IsEnum)
                    {
                        string items = " ";
                        foreach (MemberInfo x in type.GetMembers())
                        {
                            if (x.MemberType == MemberTypes.Field)
                            {
                                if (!x.Name.Equals("value__"))
                                {
                                    items = items + (" " + Enum.Parse(type, x.Name));
                                    items = items + (" " + (int)Enum.Parse(type, x.Name));
                                }
                            }
                        }
                        MessageBox.Show(items);
                    }
                
            }                    
                }
            }

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
                            foreach (var member in type.GetMembers().Where(x=>x.MemberType==MemberTypes.Field))
                            {
                                if(!member.Name.Equals("value__"))
                                    items += " " + member.Name;
                            }
                            MessageBox.Show(items);
                        }
                    
                }
            }

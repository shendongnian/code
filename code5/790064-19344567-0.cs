    var values = listBox1.SelectedItems.OfType<object>()
                         .Select(item=> item.GetType()
                                            .GetProperty(listBox1.ValueMember)
                                            .GetValue(item, null)).ToList();
                            
                            

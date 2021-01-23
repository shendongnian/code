     try
                {
    
                    List<lclsItemShdule> li = new List<lclsItemShdule>();
                    List<lclsItemShdule> li2 = new List<lclsItemShdule>();
                    foreach (clsMylist item in clbClass.CheckedItems)
                    {
                        li.AddRange(ItemScheduleDetail.Where(w => w.ClassId ==   item.ItemData).ToList());
                    }
                    
                    li2.AddRange(li);
                    li.Clear();
                    foreach (clsMylist item in clbMedium.CheckedItems)
                    {
                        li.AddRange(li2.Where(w => w.MediumId == item.ItemData).ToList());
                    }
                    li2.Clear();
                    li2.AddRange(li);
                    li.Clear();
                    foreach (clsMylist item in clbStream.CheckedItems)
                    {
                        li.AddRange(li2.Where(w => w.StreamId == item.ItemData).ToList());
                    }
                    li2.Clear();
                    li2.AddRange(li);
                    li.Clear();
                    foreach (clsMylist item in clbShift.CheckedItems)
                    {
                        li.AddRange(li2.Where(w => w.ShiftId == item.ItemData).ToList());
                    }
                    li2.Clear();
                    li2.AddRange(li);
                    
                    dgvItemSchedule.DataSource = null;
                    dgvItemSchedule.DataSource = li2;
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

    foreach (var iiitem in infosyns.MeaningList as Array)
                {
                    listBox1.Items.Add(iiitem.ToString());
                    foreach (var item in iiitem.MeaningList)
                    {
                        listBox1.Items.Add(item.ToString());
                    }
                }

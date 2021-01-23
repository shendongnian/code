    foreach(var item in new CheckBoxList[]{
                                 ScanDefaultTasks, 
                                 BehDefaultTasks,
                                 MEGDefaultTasks,
                                 DefaultQuestionnaires}
                          .SelectMany(l => l.Items))
      item.Selected = true;

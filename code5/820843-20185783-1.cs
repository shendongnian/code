    for (int i = 0; i < toolStripItems.Count; i++)
               {
                 ToolStripMenuItem mi = toolStripItems[i] as ToolStripMenuItem;
                  if (mi != null)
                {
                    if (mi.DropDownItems.Count > 0)
                    {
                        RestoreMenuStripToolTips(mi.DropDownItems);
                    }
    
                    if (oldMenuToolTips.ContainsKey(mi.Name))
                    {
                        mi.ToolTipText = oldMenuToolTips[mi.Name];
                    }
                    else
                    {
                        mi.ToolTipText = string.Empty;
                    }       // end else
                }
                }

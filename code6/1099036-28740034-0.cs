    foreach (var groupbox in ModuleTab.Controls.OfType<GroupBox>())
                {
                    foreach (var item in groupbox.Controls.OfType<CheckedListBox>())
                    {
                        for (int i = 0; i < item.Items.Count; i++)
                        {
                            item.SetItemChecked(i, false);
                        }
                    }
                }

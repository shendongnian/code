    if (listUser.SelectedItems.Count > 1)
                for (int i = 0; i < listUser.SelectedItems.Count; i++)
                {
                    Info info = listUser.SelectedItems[i] as Info;
                    info.Note = (string)tbNote.Text;
                    
                }

    public void SongList_Save(String fileName)
    {
        try
        {
            if (!String.IsNullOrEmpty(fileName) && File.Exists(fileName))
            {
                using (StreamWriter comboboxsw = new StreamWriter(fileName))
                {
                    for (int cfgitem = 0; cfgitem < LB_SongList.Items.Count; cfgitem++)
                    {
                        comboboxsw.WriteLine(GetPath((ListBoxItem)(LB_SongList.ItemContainerGenerator.ContainerFromIndex(cfgitem))));
                    }
                    comboboxsw.Close();
                }
            }
        }
        catch (Exception e)
        {
            MessageBox.Show(e.ToString());
        }
    }

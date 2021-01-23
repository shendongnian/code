    Loading_Window progress = new Loading_Window(20);
    try
    {
        progress.Show();
        if (Requests_listbox.SelectedIndex != -1)
        {
            if (Requests_listbox.SelectedItems.Count > 3)
            {
                progress.Close();
                Popup Error = new Popup("message");
                Error.ShowDialog();
                Requests_listbox.SelectedItems.Clear();
            }
            else
            {
                progress.Update_Progress(40);
                foreach (Class1 jargon in Requests_listbox.SelectedItems)
                {
                    Selection.Add(Selected_item);
                }
                progress.Update_Progress(80);
                new_window my_new_window = new new_window(Selection, Requests_listbox.SelectedItems.Count) { Owner = this };
                progress.Close();
                my_new_Window.ShowDialog();
                FillChart();
            }
        }
        else
        {
            progress.Close();
            Popup Error = new Popup("message");
            Error.Show();
            FillChart();
        }
    }
    catch (Exception ex) { MessageBox.Show(ex.ToString()); }

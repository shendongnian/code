    private void Control_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
           
           
            ObservableCollection<Picture> pictureobj=new ObservableCollection<Picture>();
            ListBox lst = (ListBox)sender;
            int i = lst.SelectedIndex;
            if (lst.SelectedValue == null)
            {
            }
            else
            {
                Pictures obj = (Pictures)lst.SelectedValue;
               ShareMediaTask shareMediaTask = new ShareMediaTask();
               shareMediaTask.FilePath = obj.yoursetterimagepath
               shareMediaTask.Show();
            }
        }

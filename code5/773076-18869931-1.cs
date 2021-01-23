     string dragSourceName = null;
     private void pbxMinotaur_MouseDown(object sender, MouseEventArgs e)
            {
                pbxMap.AllowDrop = true;
                pbxMinotaur.DoDragDrop(pbxMinotaur.Name, DragDropEffects.Copy |
                DragDropEffects.Move);
                Control c = (sender as Control);
                if(c != null)
                     dragSourceName = c.Name;
            }
        private void pbxMap_DragDrop(object sender, DragEventArgs e)
        {
            if (dragSourceName == pbxMinotaur.Name)
            {
                myDetectMouse.setMinotaur(e, myMap.myCells);
            }

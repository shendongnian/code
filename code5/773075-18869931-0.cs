     string dragSourceId = null;
     private void pbxMinotaur_MouseDown(object sender, MouseEventArgs e)
            {
                pbxMap.AllowDrop = true;
                pbxMinotaur.DoDragDrop(pbxMinotaur.Name, DragDropEffects.Copy |
                DragDropEffects.Move);
                Control c = (sender as Control);
                if(c != null)
                     dragSourceId = c.Id;
            }
        private void pbxMap_DragDrop(object sender, DragEventArgs e)
        {
            if (dragSourceId == pbxMinotaur.Id)
            {
                myDetectMouse.setMinotaur(e, myMap.myCells);
            }

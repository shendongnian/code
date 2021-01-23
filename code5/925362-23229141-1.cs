    private void cbxAttractions_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (cbxAttractions.IsChecked == false)
            {
                MainMap.Layers.Remove(mapLayerAttractions);
            }
            else
            {
                LoadAttractions();
            }
        }

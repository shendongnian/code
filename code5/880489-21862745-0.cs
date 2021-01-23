      private void comboConnections_SelectedIndexChanged(object sender, EventArgs e)
            {
                var val = comboConnections.SelectedItem;
    
                this.metaData.RuntimeConnectionCollection[0].ConnectionManagerID = ((ConnectionManager)val).ID;
            }

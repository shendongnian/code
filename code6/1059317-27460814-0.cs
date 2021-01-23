    public void ShowButton_Click(object sender, EventArgs e)
        {
            Tile requestingTile = (sender as Button).DataContext as Tile;
            if(requestingTile != null)
                MessageBox.Show("Viewing item from: " + this.Data); 
                // Or whatever else you want to do with the object...
        }

    private void btn1_Copy1_Click(object sender, RoutedEventArgs e)
    {
        if (this.MyList.SelectedIndex >= 0)
        {
            string itemName = this.MyList.Items[this.MyList.SelectedIndex].ToString();
            string[] gameParts = itemName.Split(' ');
            GamesAdd g = GamesAdd.myList.FirstOrDefault(x => x.GameName == gameParts[1]);
            GamesAdd.myList.Remove(g);
            this.MyList.Items.RemoveAt(this.MyList.SelectedIndex);
        }                
    } 

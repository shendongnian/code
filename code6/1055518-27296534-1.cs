    List<int> number = new List<int> { 0, 1, 2, 3, 4 }; //create list
    private void Button_Click_2(object sender, RoutedEventArgs e)
    {
        int numberrandom;
        Random bsd = new Random();
        if (number.Count > 0) // get random number from (numberlist) without repetition
        {
            int fIndex = bsd.Next(0, number.Count); 
            numberrandom = number[fIndex]; 
            txtbox1.Text = (numberrandom + 1).ToString(); // show random number at txtbox
            number.RemoveAt(fIndex);
        }
        else 
        { 
            MessageBox.Show("no more grid show");
        }
        var grids = new List<Grid> { grid1, grid2, grid3, grid4, grid5 };
        for (int i = 0; i < grids.Count; i++)
        {
            grids[i].Visibility = i == numberrandom ? Visibility.Visible : Visibility.Collapsed;
        }
    }

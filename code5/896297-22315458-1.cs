    if (teamList.SelectedIndex == -1)
    {
       MessageBox.Show("Please select an Item first!");
       return;
    }
    var count = File.ReadAllLines("WorldSeries.txt").Where(line => line == selectedTeam).Count();
    //var count = champList.Where(l=>l==selectedTeam).Count();
    
    if (count >0)
    {
        MessageBox.Show("The " + selectedTeam + "has won the World Series " + count  + "times! ");
    }
    else
    {
        MessageBox.Show("The " + selectedTeam + "has never won the World Series.")
    }

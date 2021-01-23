    var count = champList.Where(l=>l==selectedTeam).Count();
    
    if (count >0)
    {
        MessageBox.Show("The " + selectedTeam + "has won the World Series " + count  + "times! ");
    }
    else
    {
        MessageBox.Show("The " + selectedTeam + "has never won the World Series.")
    }

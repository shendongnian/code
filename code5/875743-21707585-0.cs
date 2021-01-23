    if (items.Any(item => item.itemid == id))
    {
        MessageBox.Show("You already giving your rating.");
        return;
    }
    RadMessageBox.Show(...);
    // etc

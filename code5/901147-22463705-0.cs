    for (int intCounter = lbSnacks.Items.Count-1; intCounter >= 0; intCounter--)
    {
        if (lbSnacks.Items[intCounter].Selected) // if the snack is selected
        { // add the listitem to the lbSelected listbox
            lbSelected.Items.Add(lbSnacks.Items[intCounter]);
            lbSnacks.Items.Remove(lbSnacks.Items[intCounter]);
        }
    }

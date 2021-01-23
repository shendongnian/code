    private void box_Paid_CheckedChanged(object sender, EventArgs e)
    { 
        // get the currently selected item
        var selectedPurchaser = Purchasers[listDOF.SelectedIndex];
        // set its state
        selectedPurchaser.Paid = box_Paid.Checked;
        // calculate the sum and display it
        UpdateSum();
    }
    private void UpdateSum()
    {
        // calculate the sum
        var sum = Purchasers.Where(x => x.Paid == false).Count() * 5;
        // update the text box (using whatever formatting you prefer)
        label_AmountLeft.Text = string.Format("${0:0.00}", sum);
    }

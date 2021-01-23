    protected void BoxReceivedClick(object sender, EventArgs e)
    {
        if (lblSupporterId.Text == "")
        {
            lblNotRawConsignmentNumber.Text = "Cannot Insert! Missing SupporterId";
            return;
        }
        else if (lblConsignmentNumber.Text == "")
        {
            lblNotRawConsignmentNumber.Text = "Cannot Insert! Missing Consignment Number";
            return;
        }
        else if (lblCollectionRequestId.Text == "")
        {
            lblNotRawConsignmentNumber.Text = "Cannot Insert! Missing Collection Request ID";
            return;
        }
        else if (Istest())
        {
            return;
        }
        InsertItemIntoReceivedBoxesTable(lblSupporterId.Text, txtReferenceNumber.Text, lblCollectionRequestId.Text);
        BindReceivedBoxes();
        ClearLabels();
    }

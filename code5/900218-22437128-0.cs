    if (index >= 0 && index < mDS.Attachment.DefaultView.Count)
    {
        int tempSelInd = index;
        mDS.Attachment.DefaultView[index].Row.Delete();
        mSelectedAttachmentIndex = Math.Min(mDS.Attachment.DefaultView.Count - 1, tempSelInd );
        RaisePropertyChanged(this, "Attachments");
        RaisePropertyChanged(this, "SelectedAttachmentIndex");
    }

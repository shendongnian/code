        if(!AlreadyDisplayedAccessionNumber.Contains(TryGetString(currObj,DICOM_TAGS_ENUM.AccessionNumber)))
    {
        MessageBox.Show("New scan found"); 
        AlreadyDisplayedAccessionNumber.Add(TryGetString(currObj,DICOM_TAGS_ENUM.AccessionNumber);//add to our list this new accession number which we only reported it as new
    }

        if(!AlreadyDisplayedAccessionNumber.Contains(TryGetString(currObj,DICOM_TAGS_ENUM.AccessionNumber)))
    {
    //do not display this message if we are loading the details first time round
    if(!IsFirstLoad) 
    {
        MessageBox.Show("New scan found"); 
    }
        AlreadyDisplayedAccessionNumber.Add(TryGetString(currObj,DICOM_TAGS_ENUM.AccessionNumber);//add to our list this new accession number which we only reported it as new
    }

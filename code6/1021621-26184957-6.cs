    int i;
    bool bl;
    Bitmap bitmapToCompareWith = new Bitmap(...); //your bitmap to use as reference 
                                                  //for your comparisons
    for (i = 0; i < bitmapListToCompare.Count; i++)
    {
        bl = ImageComparison(bitmapToCompareWith, bitmapListToCompare[i], ...., ....);
        if (bl == false)
        {
            MessageBox.Show("Image " + i.ToString() + " was different!");
            break;
        }
    }

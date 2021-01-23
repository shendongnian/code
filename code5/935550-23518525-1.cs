    if(buttonCount == 2)
    {
        if(((GameImage)pictureList[0].Image).FileName == ((GameImage)pictureList[1].Image).FileName)
        {
            buttonCount = 0;
            buttonList.RemoveAt(0)
            buttonList.RemoveAt(0);
            pictureList.RemoveAt(0);
            pictureList.RemoveAt(0);
        }
    }

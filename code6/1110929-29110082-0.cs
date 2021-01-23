    var prevLength = 0;
    foreach (var item in mockStructureList)
    {
        if (rowCounter == 0)
            System.Buffer.BlockCopy(item, 0, fileContentPostSAP, 0, item.Length);
        else
            System.Buffer.BlockCopy(item, 0, fileContentPostSAP, prevLength, item.Length);
        rowCounter++;
        prevLength = item.Length;
    }

    byte[,] imageData = new byte[1, 2]
    { 
        {  1,  2 }
        {  3,  4 }
     };
    var mergedData = new byte[ImageData.Length];
    // Output { 1, 2, 3, 4 }
    Buffer.BlockCopy(imageData, 0, mergedData, 0, imageData.Length);

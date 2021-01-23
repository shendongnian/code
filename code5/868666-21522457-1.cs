    // Try increasing MaxDegreeOfParallelism
    var opt = new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = 2 };
    // Create the blocks
    // You must define the functions to do what you want
    var paintBlock = new TransformBlock<Bitmap, Bitmap>(fnPaintText, opt);
    var cropBlock = new TransformBlock<Bitmap, Bitmap>(fnCrop, opt);
    var resizeBlock = new TransformBlock<Bitmap, Bitmap>(fnResize, opt);
    var reduceBlock = new TransformBlock<Bitmap, Bitmap>(fnReduce,opt);
    // Link the blocks together
    paintBlock.LinkTo(cropBlock);
    cropBlock.LinkTo(resizeBlock);
    resizeBlock.LinkTo(reduceBlock);
    // Send data to the first block
    // ListOfImages contains your original frames
    foreach (var img in ListOfImages) { 
       paintBlock.Post(img);
    }
    // Receive the modified images
    var outputImages = new List<Bitmap>();
    for (int i = 0; i < ListOfImages.Count; i++) {
       outputImages.Add(reduceBlock.Receive());
    }
    // outputImages now holds all of the frames
    // reassemble them in order

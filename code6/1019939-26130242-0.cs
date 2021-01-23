    private static void FillBlock(DirectoryInfo directoryInfo, XYZTileCombinerBlock<FileInfo> block)
    {
        foreach (var fileInfo in directoryInfo.GetFiles())
        {
            block.Post(fileInfo);
        }
        foreach (var subDirectory in directoryInfo.GetDirectories())
        {
            FillBlock(subDirectory, block);
        }
    }

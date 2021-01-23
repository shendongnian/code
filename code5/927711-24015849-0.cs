            var inputAsset = context.Assets.Where(a => a.Id == inputAssetId).FirstOrDefault();
            if (inputAsset == null)
                throw new ArgumentException("Could not find assetId: " + inputAssetId);
            var encodingPreset = "H264 Adaptive Bitrate MP4 Set SD 16x9"; // <a href="http://msdn.microsoft.com/en-us/library/windowsazure/jj129582.aspx#H264Encoding">http://msdn.microsoft.com/en-us/library/windowsazure/jj129582.aspx#H264Encoding</a>
            var encodingPresetConfig = File.ReadAllText(@"D:\WAMS\DynamicPackagingUpload\DynamicPackagingUpload\DynamicPackagingUpload\Encoding.xml");
            IJob job = context.Jobs.Create("Encoding " + inputAsset.Name + " to " + encodingPreset);
            IMediaProcessor latestWameMediaProcessor = (from p in context.MediaProcessors where p.Name == "Windows Azure Media Encoder" select p).ToList()
                                                                         .OrderBy(wame => new Version(wame.Version)).LastOrDefault();
            ITask encodeTask = job.Tasks.AddNew("Encoding", latestWameMediaProcessor, encodingPresetConfig, TaskOptions.None);
            encodeTask.InputAssets.Add(inputAsset);
            encodeTask.OutputAssets.AddNew(inputAsset.Name + " as " + encodingPreset, AssetCreationOptions.None);

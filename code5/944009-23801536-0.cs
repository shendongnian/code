    public class MyAssetRepository : IMyAssetRepository
    {
        public MyAsset Get(int assetId)
        {
            using (var context = new AssetContext())
            {
                var selectedAsset = context.MyAssets.Include(a => a.MyConfigs).Single(a => a.Id == assetId);
                selectedAsset.MyConfigs = selectedAsset.MyConfigs
                    .Where(c => c.InstanceNumber == selectedAsset.InstanceValue)
                    .ToList();
                return selectedAsset;
            }
        }
    }

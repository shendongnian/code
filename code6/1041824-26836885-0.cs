    public class RequiredThumbnailAssetId : ModelAwareValidationAttribute
    {
        static RequiredThumbnailAssetId() { Register.Attribute(typeof(RequiredThumbnailAssetId)); }
        public async override Task<bool> CheckValid(object value, object container)
        {
            var valid = AsyncHelpers.RunSync<bool>(() => isValid(value,container));
            return valid;
        }
        public override bool IsValid(object value, object container)
        {
            var model = (IGridViewItemWithAssetId)container;
            if (model.thumbnailAssetId <= 0)
            {
                return false;
            }
            CanFindLocationDatabaseContext db = new CanFindLocationDatabaseContext();
            Asset asset = await db.assets.FindAsync(model.thumbnailAssetId);
            if (asset == null)
            {
                return false;
            }
            return true;
        }

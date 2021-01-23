csharp
public async Task<TimeSpan> GetVideoDurationAsync(string encodedAssetName)
{
    var encodedAsset = await ams.Assets.GetAsync(config.ResourceGroup, config.AccountName, encodedAssetName);
    if(encodedAsset is null) throw new ArgumentException("An asset with that name doesn't exist.", nameof(encodedAssetName));
    var sas = GetSasForAssetFile("video_manifest.json", encodedAsset, DateTime.Now.AddMinutes(2));
    var responseMessage = await http.GetAsync(sas);
    var manifest = JsonConvert.DeserializeObject<Amsv3Manifest>(await responseMessage.Content.ReadAsStringAsync());
    var duration = manifest.AssetFile.First().Duration;
    return XmlConvert.ToTimeSpan(duration);
}
For the `Amsv3Manifest` model and a sample `video_manifest.json` file, see: https://app.quicktype.io/?share=pAhTMFSa3HVzInAET5k4
You may use the following definition of `GetSasForAssetFile()` to get started:
csharp
private string GetSasForAssetFile(string filename, Asset asset, DateTime expiry)
{
    var client = GetCloudBlobClient();
    var container = client.GetContainerReference(asset.Container);
    var blob = container.GetBlobReference(filename);
    
    var offset = TimeSpan.FromMinutes(10);
    var policy = new SharedAccessBlobPolicy
    {
        SharedAccessStartTime = DateTime.UtcNow.Subtract(offset),
        SharedAccessExpiryTime = expiry.Add(offset),
        Permissions = SharedAccessBlobPermissions.Read
    };
    var sas = blob.GetSharedAccessSignature(policy);
    return $"{blob.Uri.AbsoluteUri}{sas}";
}
private CloudBlobClient GetCloudBlobClient()
{
    if(CloudStorageAccount.TryParse(storageConfig.ConnectionString, out var storageAccount) is false)
    {
        throw new ArgumentException(message: "The storage configuration has an invalid connection string.", paramName: nameof(config));
    }
    return storageAccount.CreateCloudBlobClient();
}

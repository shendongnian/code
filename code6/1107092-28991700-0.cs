    var sas = blob.GetSharedAccessSignature(new SharedAccessBlobPolicy()
              {
                  Permissions = SharedAccessBlobPermissions.Write | SharedAccessBlobPermissions.Delete,
                  SharedAccessExpiryTime = DateTime.UtcNow.AddMinutes(Convert.ToDouble(ConfigurationManager.AppSettings["SharedAccessSignatureExpiryTimeOffset"]))
              });

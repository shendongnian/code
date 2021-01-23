    if (!data.ExistingImage) {
        if (data.Image == null) {
            S3Utility.Delete(myObject.Id);
        } else {
            S3Utility.Upload(data.Image, myObject.Id);
        }
    }

    bool error;
    using (var session = await _db.StartSessionAsync())
    {
        session.StartTransaction();
        try
        {
            var deletedImage = _db.GetUserStore<ApplicationUser>().CollectionInstance.UpdateOneAsync(
                Builders<ApplicationUser>.Filter.Where(w => w.Id == userId),
                Builders<ApplicationUser>.Update.Pull(x => x.ProfilePictures, photoFromRepo));
            await _db.ProfilePicture().DeleteAsync(new ObjectId(photoFromRepo.ImageId));
            if (photoFromRepo.CloudinaryPublicId != null)
            {
                var deleteParams = new DeletionParams(photoFromRepo.CloudinaryPublicId);
                var result = _cloudinary.Destroy(deleteParams);
                if (result.Result == "ok")
                {
                    // ignore
                }
                else
                {
                    throw new Exception("Cannot delete file from cloud service...");
                }
            }
            await session.CommitTransactionAsync();
            error = false;
        }
        catch (Exception ex)
        {
            await session.AbortTransactionAsync();
            error = true;
        }
    }

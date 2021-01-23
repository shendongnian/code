    public void RemoveOldPhotoItem(ImageFileViewModel imageFile)
            {
                this._allImages.Remove(imageFile);
                this.DataItemsCount++;
                File.Delete(imageFile.FileName);
            }

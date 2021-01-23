            var user = e.Object as IUser;
            if (user != null)
            {
                var myPage = MyPageHandler.Instance.GetMyPage(user);
                if (myPage != null && myPage.ImageGallery != null)
                {
                    foreach (var imageGallery in myPage.ImageGallery.Children)
                    {
                        var imageGalleryClone = imageGallery.CreateWritableClone() as ImageGallery;
                        imageGalleryClone.SetOwner(user);
                        ImageGalleryHandler.Instance.UpdateImageGallery(imageGalleryClone);
                    }
                }
            }

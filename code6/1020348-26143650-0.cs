    public void CheckDownloadImage()
        {
            var camera = GetCamera();
            var image=camera.Contents().ImagesAsync().Result.FirstOrDefault();
            if (image == null)
                Assert.Inconclusive("no image found");
            var response=image.DownloadAsync().Result.GetResponseStream();
            var memory = ReadToMemory(response);
            Assert.AreEqual(memory.Length, image.Size);
        }

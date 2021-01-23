        void cam_Completed(object sender, PhotoResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                using (MemoryStream memo = new MemoryStream())
                {
                    e.ChosenPhoto.CopyTo(memo);
                    memo.Position = 0;
                    using (ExifReader reader = new ExifReader(memo))
                    {
                        double[] latitudeComponents;
                        reader.GetTagValue(ExifTags.GPSLatitude, out latitudeComponents);
                        double[] longitudeComponents;
                        reader.GetTagValue(ExifTags.GPSLongitude, out longitudeComponents);
                        // Lat/long are stored as D°M'S" arrays, so you will need to reconstruct their values as below:
                        var latitude = latitudeComponents[0] + latitudeComponents[1] / 60 + latitudeComponents[2] / 3600;
                        var longitude = longitudeComponents[0] + longitudeComponents[1] / 60 + longitudeComponents[2] / 3600;
                        // latitude and longitude should now be set correctly...
                    }
                }
            }
        }

            var pics = db.AlbumPictures.Where(x => x.ID == albumID);
            //Will be used to hold each picture in the sequence
            JArray dynamicPics = new JArray();
            foreach (var pic in pics)
            {
                //Convert your object to JObject
                JObject dynamicPic = JObject.FromObject(pic);
                //Create your dynamic properties here.
                dynamicPic["Thumbnail"] = ThumbManager.GetThumb(pic.ID);
                dynamicPics.Add(dynamicPic);
            }
            //Convert the dynamic pics to the json string.
            string json = dynamicPics.ToString();
            //Return the json as content, with the type specified.
            return this.Content(json, "application/json");

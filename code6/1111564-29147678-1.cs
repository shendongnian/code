    public static class Util
    {
        public static IDictionary<string, object> ToDict(this object jsonObject)
        {
            return (IDictionary<string, object>)jsonObject;
        }
        public static string DeserializePictureURLObject(this object pictureObj)
        {
            // Adapted from http://answers.unity3d.com/questions/921336/found-my-highscore-on-facebook.html?sort=oldest
            var picture = pictureObj.ToDict()["data"].ToDict();
            object urlH = null;
            if (picture.TryGetValue("url", out urlH))
            {
                return (string)urlH;
            }
            return null;
        }
    }

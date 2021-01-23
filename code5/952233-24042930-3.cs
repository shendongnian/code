        public string AddPlace(Place placeBounds, ...)
        {
			FetchAllSocialPlatforms(placeBounds);
			
            Place newPlace = PlaceDB.AddPlace(placeBounds, ...);
            return new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(newPlace);
        }

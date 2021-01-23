		public string GetBodyAsText()
		{
            return Encoding.UTF8.GetString(Body);
            // Original gets ?? characters instead of unicode ones
            //return BodyEncoding.GetString(Body);
		}

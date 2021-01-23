        public static bool CheckInvite(string fromId, string toId)
        {
            var fb = new FacebookClient(APP_ID + "|" + SECRET_ID);
            fb.AppId = APP_ID;
            fb.AppSecret = SECRET_ID;
            dynamic result = fb.Get(string.Format("/{0}/apprequests", toId));
            foreach (var el in result.data)
                if ((string)el.from.id == fromId)
                {
                    DateTime dateTime = DateTime.Parse((string)el.created_time, CultureInfo.InvariantCulture);
                    if ((DateTime.Now - dateTime).TotalMinutes < 15)
                    {
                            return true;
                    }
                }
            return false;
        }

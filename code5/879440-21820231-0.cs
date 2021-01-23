       public static DataTable arkadasListe()
        {
             DataTable dtableArkadasTablosu = new DataTable("friends");
            dtableArkadasTablosu.Columns.Add("name", Type.GetType("System.String"));
            dtableArkadasTablosu.Columns.Add("id", Type.GetType("System.String"));
            face.client.AccessToken = face.accesstoken;/
            var param = new Dictionary<string, object>();
            param["fields"] = "friends";
            if (face.client.AccessToken==null)
            {
                return dtableArkadasTablosu;
      
            }
            if (string.IsNullOrEmpty(face.client.AccessToken))
            {
                
                return dtableArkadasTablosu;
            }
            Facebook.JsonObject a = (Facebook.JsonObject)face.client.Get("me", param);
           
            if (a.Count==1)
            {
                return dtableArkadasTablosu;//bos tabloyu gonder
            }
          
            Facebook.JsonObject arr = (Facebook.JsonObject)a[1];//its friend list
            var arrs = (Facebook.JsonObject)arr;
           
          
            foreach (var friend in (JsonArray)arr["data"])//friends are in the data key
            {
                DataRow drowEklenecek = dtableArkadasTablosu.NewRow();//tablomuzdan yenı bır satır turetıyoruz
                string Id = (string)(((JsonObject)friend)["id"]).ToString();
                string Name = (string)(((JsonObject)friend)["name"]).ToString();
                drowEklenecek["name"] = Name;
                drowEklenecek["id"] = Id;
                dtableArkadasTablosu.Rows.Add(drowEklenecek);
                
                
            }
            return dtableArkadasTablosu;//dongu bıttıgınde arkadaslarımızı barındıran tablo hazır demektır.tabloyu gonder.
           
           
        }

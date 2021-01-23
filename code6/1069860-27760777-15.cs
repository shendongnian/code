            var json = e.Result;
            var jobject = ParseWithMissingBraces(json);
            var serializer = new JsonSerializer();
            serializer.Converters.Add(new ResponseDataConverter());
            var songList = jobject["response"].ToObject<SongList>(serializer);
            var songs = songList.Songs;
            var users = songList.Users;

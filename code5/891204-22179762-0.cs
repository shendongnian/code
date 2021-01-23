    client.ExecuteAsync(request, response =>
        {
            RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(response.Content);
            foreach (Datum obj in rootObject.data)
            {
                var Name = obj.user.full_name;
                var Caption = obj.caption.text;
                var picURL = obj.images.low_resolution.url;
    
                System.Console.WriteLine("Name of " + Name + ", Caption of " + Caption + ", and picurl of " + picURL);
            }
        }
    );

    Uri uri = new Uri("mysharpeointurl/_api/web/Lists/GetByTitle('libraryname')/Items?$select=ID,Title");
            var response = client.GetAsync(uri);
            string text = await response.Result.Content.ReadAsStringAsync();
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Returned.RootObject));
            Returned.RootObject rootObject = null;
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(text))) {
                var documentdata = (Returned.RootObject)serializer.ReadObject(ms);
                rootObject = documentdata;
            }
            return rootObject;

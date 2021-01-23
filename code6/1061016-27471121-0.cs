    public void Test()
        {
            string json = "[{\"id\":12},{\"id\":2,\"children\":[{\"id\":3},{\"id\":4}]}]";
            var objects = JsonConvert.DeserializeObject<List<MenuJson>>(json);
            foreach (var property in objects)
            {
                var id = property.id;
                foreach (var child in property.children)
                {
                    //child
                }
            }
        }

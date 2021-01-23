    Product product = new Product();
    product.Name = "Apple";
    product.Expiry = new DateTime(2008, 12, 28);
    product.Sizes = new string[] { "Small" };
     
    string json = JsonConvert.SerializeObject(product);
    //{
    //  "Name": "Apple",
    //  "Expiry": "2008-12-28T00:00:00",
    //  "Sizes": [
    //    "Small"
    //  ]
    //}
    string json = @"{
      'Name': 'Bad Boys',
      'ReleaseDate': '1995-4-7T00:00:00',
      'Genres': [
        'Action',
        'Comedy'
      ]
    }";
    
    Movie m = JsonConvert.DeserializeObject<Movie>(json);
    
    string name = m.Name;
    // Bad Boys

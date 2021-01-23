    ...
    public class Movie
    {
       public string Name;
       public DateTime ReleaseDate;
       public string[] Genres;
    }
    ......
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

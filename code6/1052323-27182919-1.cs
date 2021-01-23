            List<MovieDetail> movies = new List<MovieDetail>();
            foreach (String filename in filenames)
            {
                Match regex_match = Regex.Match(filename.Trim(), regex_pattern);
                String matched_movie_name = regex_match.Groups[1].Value;
                movies.Add(new MovieDetail { Image = new BitmapImage(new Uri(filename)), Name = matched_movie_name });
            }
            MovieListView.ItemsSource = movies;

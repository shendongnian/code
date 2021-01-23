    public static void Fill(AcroFields form, Movie movie) {
        form.SetField("title", movie.MovieTitle);
        form.SetField("director", GetDirectors(movie));
        form.SetField("year", movie.Year.ToString());
        form.SetField("duration", movie.Duration.ToString());
        form.SetField("category", movie.entry.category.Keyword);
        foreach (Screening screening in movie.entry.Screenings) {
            form.SetField(screening.Location.Replace('.', '_'), "Yes");
        }
    }

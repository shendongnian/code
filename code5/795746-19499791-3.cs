    private void ValidateUniqueName(Genre genre)
    {
        string errorMessage = "The genre name must be unique";
        if (!IsGenreNameUnique(genre))
        {
            if (!genre.ExternalErrors.Contains(errorMessage)) genre.ExternalErrors.Add(errorMessage);
        }
        else genre.ExternalErrors.Remove(errorMessage);
    }

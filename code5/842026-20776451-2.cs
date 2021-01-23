    private void buttonUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            List<Movie> movies = listBoxForMovies.Datasource as List<Movie>;
            Movie Movie1 = new Movie();
            Movie1.Name= textBoxName.Text;
            Movie1.ReleaseDate = Convert.ToDateTime(textBoxReleaseDate.Text);
            Movie1.LenghtInMinutes= Convert.ToInt32(textBoxLenghtInMinutes.Text);
            Movie1.Update();
            movies.Add(Movie1);
            MessageBox.Show("Changes saved");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

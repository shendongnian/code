    private void buttonUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            // Here we need to get the current movie from the current item 
            // selected in the listbox and update this instance
            if(listBoxForMovies.SelectedItem != null) 
            {
                 Movie currentMovie = listBoxForMovies.SelectedItem as Movie;
                 currentMovie.Name= textBoxName.Text;
                 currentMovie.ReleaseDate = Convert.ToDateTime(textBoxReleaseDate.Text);
                 currentMovie.LenghtInMinutes= Convert.ToInt32(textBoxLenghtInMinutes.Text);
                 currentMovie.Update();
                 MessageBox.Show("Changes saved");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

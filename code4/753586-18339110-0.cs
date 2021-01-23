    private void moviesGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
      if (dataGridView1.Columns["colDetailButton"].DisplayIndex == e.ColumnIndex)
      {
        // my guess is you also need other data, like the movie's IMDB number
        string imdbValue = dataGridView1.Rows[e.RowIndex].Cells["colImdbValue"].Value.ToString();
        using (var form = new MovieDetailsForm(MovieDetailsForm.MovieViewMode.Read))
        {
          form.ImdbValue = imdbValue;
          form.ShowDialog();
        }
      }
      else
      {
        // Remove this debugging code once you get your code working
        Console.WriteLine("ColumnIndex {0} was clicked." e.ColumnIndex);
      }
    }

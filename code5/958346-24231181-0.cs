    public List<MovieData> getAllMoviesSorted(string column)
    {
        List<MovieData> movieData = db.GetAllData();
        switch(column.ToUpper())
        {
            case "ORDERDATE":
                movieData = movieData.OrderBy(o=>o.OrderDate).ToList(); 
                break;
            // add more cases
            default:
                throw new Exception("Column " + column + " cannot be found.");       
        }
        return movieData;
    }

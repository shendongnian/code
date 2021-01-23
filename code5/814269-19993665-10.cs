    public ActionResult Edit(int id)
    {
        var _Movie = Movie.GetMovieById(id);
        var _Comments = Comments.GetCommentsByMovieId(id);
    
        var _MovieModel = new MovieModel();
        _MovieModel.MovieId = _Movie.MovieId;
        _MovieModel.MovieName = _Movie.MovieName;
        _MovieModel.MovieComments = (from Comment _Comment in _Comments select new
        CommentModel{ CommentId = _Comment.CommentId , CommentText = _Comment.CommentText }).ToList();
        
        return View(_MovieModel);
    }

    public class MoviewViewModel
    {
        public MoviewViewModel(){
           cinema = new List<CinemaViewModel>();
        }
        public int movieid;
        public int userid;
        public string moviename;
        public List<CinemaViewModel> cinema;
    }
    public class UserandMovieViewModel
    {
        public UserandMovieViewModel(){
            movie = new List<MoviewViewModel>();
        }
        public List<MoviewViewModel> movie;
        pubic UserViewModel user;
    }

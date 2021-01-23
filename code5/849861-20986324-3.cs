    public class BoardViewModel
    {
        public BoardViewModel()
        {
            var rand = new Random();
            Squares = Enumerable
                .Range(1, 42)
                .Select(a => new SquareViewModel() { Token = rand.Next(-1, 2) })
                .ToList();
        }
        public List<SquareViewModel> Squares { get; set; }
    }

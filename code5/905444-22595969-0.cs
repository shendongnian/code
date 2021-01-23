    public class TestViewModel
    {
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please supply the title.")]
        [System.ComponentModel.DataAnnotations.Display(Name = "Title")]
        public Title? Title { get; set; }
    }
    public enum Title
    {
        Mr = 0,
        Mrs = 1,
        Miss = 2,
        Dr = 3
    }

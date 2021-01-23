    public GamePage()
    {
        InitializeComponent();
        this.DataContext = GamePageViewModel();
        for (int x = 1; x <= row; x++)
        {
            for (int i = 1; i <= column; i++)
            {
                CreateButtons(SeatValue.ToString() + i, locationFirst, locationSecond);
                locationFirst = locationFirst + 130;
            }
            locationFirst = 25;
            locationSecond = locationSecond + 50;
        }
    }
    public class GamePageViewModel
    {
       //List of numbers to put e.g. List<int>
       //Change PropertyNameOfTheViewModel here to properties, say 10 properties e.g, public int Content { get; set; }
    } 
    Button btnNew = new Button();
    btnNew.Name = btnName;
    btnNew.Margin = new Thickness(btnPointFirst, btnPointSecond, 0, 0);
    btnNew.Width = 100;
    btnNew.Height = 70;
    btnNew.SetBinding(Button.ContentProperty,new Binding("PropertyNameOfTheViewModel");

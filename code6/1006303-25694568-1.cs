    public class MyPage : Page {
        public string ButtonText {
            set { 
                LogicalChildren
                    .OfType<Button>()
                    .ToList()
                    .ForEach(b => b.Text = value); 
            }
        }
    }

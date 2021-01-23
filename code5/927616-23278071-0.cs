    class Program
    {
        [STAThread] 
        static void Main(string[] args)
        {
            var request = new TripRequest() {Airline = "Reflection Airways"};
            var window = new Window();
            var stackPanel = new StackPanel();
            window.Content = stackPanel;
            foreach (var property in request.GetType().GetProperties())
            {
                Console.WriteLine("Property named {0} has type {1}", property.Name, property.PropertyType);
                if (property.PropertyType == typeof(string))
                {
                    var textBox = new TextBox();
                    var binding = new Binding();
                    binding.Source = request;
                    binding.Path = new PropertyPath(property.Name);
                    BindingOperations.SetBinding(textBox, TextBox.TextProperty, binding);
                    stackPanel.Children.Add(textBox);
                }
                // etc for other types you care about
            }
            window.ShowDialog();
            Console.WriteLine("Airline is now {0}",request.Airline);
            Console.WriteLine("Finished");
        }
    }
    class TripRequest
    {
        public string Airline { get; set; }
        public int Price { get; set; }
    }

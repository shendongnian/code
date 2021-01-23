    public class MyFloatingObject : GrapeCity.Windows.SpreadSheet.UI.CustomFloatingObject
        {
            public MyFloatingObject(string name, double x, double y, double width, double height)
                : base(name, x, y, width, height)
            {
            }
            public override FrameworkElement Content
            {
                get
                {
                    Border border = new Border();
                    StackPanel sp = new StackPanel();
                    sp.Children.Add(new Button() { Content = "Button" });
                    border.BorderThickness = new Thickness(1);
                    border.BorderBrush = new SolidColorBrush(Colors.Black);
                    border.Child = sp;
                    return border;
                }
            }
        }

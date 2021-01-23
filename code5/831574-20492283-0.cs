    public class Petrinet
    {
        public void OutputPetrinet(Canvas dest)
        {
            if (dest == null) {
                throw new ArgumentNullException("dest");
            }
            
            Ellipse e = new Ellipse() {
                Width = 50,
                Height = 60,
                Fill = Brushes.Blue
            };
            Canvas.SetLeft(e, 20);
            Canvas.SetTop(e, 30);
            dest.Children.Add(e);
        }
    }

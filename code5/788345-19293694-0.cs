    public class CreateControl
    {
        public Control Create(string name, Point location, Size size)
        {
            Panel p = new Panel();
            p.Name = name;
            p.Location = location;
            p.Size = size;
            p.BackColor = Color.Red;
            return p;
        }
    }

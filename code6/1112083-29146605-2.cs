    public class MyControlCollection : Control.ControlCollection
    {
        public MyControlCollection(Control owner) : base(owner)
        {
        }
        public override void Add(Control value)
        {
            // Modify whatever type of control you want to here
            if (value is Button)
            {
                // As an example, I will set the BackColor of all buttons added to the form to red
                Button b = (Button)value;
                b.BackColor = Color.Red;
            }
            base.Add(value);
        }
    }

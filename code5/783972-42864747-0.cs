    int id = 4;
    Type t = e.GetType();
    if (t.Equals(typeof(MouseEventArgs)))
    {
        MouseEventArgs mouse = (MouseEventArgs)e;
        if (mouse.Button == MouseButtons.Left)
        {
            Console.WriteLine("****Left!!");
        }
        if (mouse.Button == MouseButtons.Right)
        {
            Console.WriteLine("****Right!!");
        }
                
    }
}

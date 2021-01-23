    public Form1()
    {
        InitializeComponent();
        
        // do your initialization
        ...
        
        // assign the events to the ShapeContainer
        // don't forget to remove the handlers from ovalShape3 in the designer!!!
        ShapeContainer container = ovalShape3.Parent;
        container.MouseUp += ovalShape3_MouseUp;
        container.MouseDown += ovalShape3_MouseDown;
        container.MouseMove += ovalShape3_MouseMove;
    }

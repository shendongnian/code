    Label myLabel = new Label();
    myLabel.Text = "BOB";
    Rectangle rec = myLabel.Bounds;
    Rectangle rec2 = new Rectangle(30, 10, 20, 40);
    Rectangle intersect = Rectangle.Intersect(rec, rec2);
    if (intersect != Rectangle.Empty)
    {
       MessageBox.Show("Intersection!");
    }

        private void CreateBox(int X, int Y, int ObjectType)
        {
        ShapeContainer canvas = new ShapeContainer();
        RectangleShape box = new RectangleShape();
        box.Parent = canvas;
        box.Size = new System.Drawing.Size(100, 90);
        box.Location = new System.Drawing.Point(X, Y);
        box.Name = "Box" + ObjectType.ToString();
        box.BackColor = Color.Transparent;
        box.BorderColor = Color.Transparent;
        box.BackgroundImage = img.Images[ObjectType];// Load from imageBox Or any resource
        box.BackgroundImageLayout = ImageLayout.Stretch;
        box.BorderWidth = 0;
        canvas.Controls.Add(box);   // For feature use 
        }
 

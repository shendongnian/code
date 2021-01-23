        public A(Bitmap pathOfMovingObject, int xPositionObject, int yPositionObject, int widthOfObject, int heightOfObject)
            {
                path = pathOfMovingObject;
                x = xPositionObject;
                y = yPositionObject;
                width = widthOfObject;
                height = heightOfObject;
    
    picBoxImage = new PictureBox();
                picBoxImage.Image = pathOfMovingObject;
                picBoxImage.BackColor = Color.Transparent;
                picBoxImage.SetBounds(xPositionObject, yPositionObject, widthOfObject, heightOfObject);
                this.Controls.Add(picBoxImage);
            }

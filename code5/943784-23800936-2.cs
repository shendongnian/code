        public void Rotate(float deg)
        {
            RotateTransform rt = new RotateTransform(deg);
            image2.RenderTransform = rt;
        }

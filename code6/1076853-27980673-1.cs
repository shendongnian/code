    Timer tm = new Timer(ChangeColor, color, 0, 1000);
            private void ChangeColor(object color)
            {   
                Color backColor = color as Color;
                // camera is member variable
                if (color!= null)
                {
                    camera.backgroundColor = backColor ;
                }
            }

                    if (direction.ToString() == "Right")
                {
                    Application.ActivePresentation.SlideShowWindow.View.Next();
                    LastGesture = DateTime.Now;
                }
                if (direction.ToString() == "Left")
                {
                    Application.ActivePresentation.SlideShowWindow.View.Previous();
                    LastGesture = DateTime.Now;
                }

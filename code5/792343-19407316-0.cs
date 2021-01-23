          public void AddRectangleAtPosition(int x, int y)
                {
                    Coos.Add(new Coordinates(x, y));
    if (PropertyChanged != null)
                            {
                                PropertyChanged(this, new PropertyChangedEventArgs("Coos"));
                            }
                }

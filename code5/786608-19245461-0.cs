     if (isVisible && count % 2 == 0)
        {
            count++;
            return new SolidColorBrush(Color.FromArgb(255,200,200,200)); //dark color
        }
        else if (isVisible && count % 2 == 1)
        {
            count++;
            return new SolidColorBrush(Color.FromArgb(255,225,225,225)); //light color
        }

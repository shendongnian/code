        ListBox elementListBox = new ListBox();
        elementListBox.Name = "elementListBox" + indexOfElement;
        elementListBox.VerticalAlignment = VerticalAlignment.Top;
        targetElement.Items.Remove(addFloor);
        targetElement.Items.Add(elementListBox);
        elementListBox.Items.Add(putElements("TEST", index));
        targetElement.Items.Add(addFloor);
        return true;
    }
    public object putElements(string nameOfElement, int indexOfElement)
    {
        if (nameOfElement.Contains("TEST"))
        {
            Button floorButton = new Button();
            floorButton.Name = "floorButton" + indexOfElement;
            floorButton.Content = "floorButton" + indexOfElement;
            floorButton.Height = 60;
            floorButton.Width = 87;
            floorButton.Margin = new Thickness(0, 2, 0, 0);
            return floorButton;
        }
    }

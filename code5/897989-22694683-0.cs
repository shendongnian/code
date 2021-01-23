        var p = new Popup()
        {
            PlacementRectangle = new Rect( cs.X, cs.Y, 40, 60 ),
            Placement = PlacementMode.Custom,
            CustomPopupPlacementCallback = new CustomPopupPlacementCallback( placePopup ),
            StaysOpen = false,
            Child = img,
        }; 
        

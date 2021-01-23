    private CustomPopupPlacement[] placePopup( Size popupSize, Size targetSize, Point offset )
    {
        Debug.WriteLine( "{0}; {1}; {2}", popupSize.ToString(), targetSize.ToString(), offset.ToString() );
        return new[] { 
            new CustomPopupPlacement( new Point( -50, targetSize.Height ), PopupPrimaryAxis.Vertical ),
            new CustomPopupPlacement( new Point( -50, -popupSize.Height ), PopupPrimaryAxis.Vertical ),
        };
    }

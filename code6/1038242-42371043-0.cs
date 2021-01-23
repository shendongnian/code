    panel.RightClick();
    var popup = _mainWindow.Popup;
    var properties_item = popup.ItemBy(
      SearchCriteria.ByText( "Propeties" )
    );
    properties.item.Click();

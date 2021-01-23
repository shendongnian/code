    private void pbxMap_MouseHover(object sender, System.EventArgs e)
    {
        var xPosition = pbxMap.PointToClient(MousePosition).X;
        mapConstructor.onMouseUp(xPosition, map.cellPositions, map.cellPositions);
    }

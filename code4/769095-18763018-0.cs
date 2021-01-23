     private void drawRegion()
        {
            GraphPane pane = zedGraphControl1.GraphPane;
            BoxObj box = new BoxObj(0, 20, 500, 10,Color.Empty, Color.LightYellow);
            
            box.Location.CoordinateFrame = CoordType.AxisXYScale;
            box.Location.AlignH = AlignH.Left;
            box.Location.AlignV = AlignV.Top;
            
            // place the box behind the axis items, so the grid is drawn on top of it
            box.ZOrder = ZOrder.E_BehindCurves;
            pane.GraphObjList.Add(box);
            // Add Region text inside the box 
            TextObj myText = new TextObj("Threshold limit", 100, 15);
            myText.Location.CoordinateFrame = CoordType.AxisXYScale;
            myText.Location.AlignH = AlignH.Right;
            myText.Location.AlignV = AlignV.Center;
            myText.FontSpec.IsItalic = true;
            myText.FontSpec.FontColor = Color.Red;
            myText.FontSpec.Fill.IsVisible = false;
            myText.FontSpec.Border.IsVisible = false;
            pane.GraphObjList.Add(myText);
            zedGraphControl1.Refresh();
        }

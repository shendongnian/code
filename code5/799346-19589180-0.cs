                Currentposition = Station.Position;
    
                TouchPanelCapabilities touchCap = TouchPanel.GetCapabilities();
                if (touchCap.IsConnected)
                {
                    TouchCollection touches = TouchPanel.GetState();
                    if (touches.Count >= 1)
                    {
                        Vector2 PositionTouch = touches[0].Position;
                        for (int i = 0; i < ListDragObj.Count(); i++)
                        {
                            if (ListDragObj[i].Shape.Contains((int)PositionTouch.X, (int)PositionTouch.Y))
                            {
                                ListDragObj[i].selected = true;
                            }
                            else
                            {
                                ListDragObj[i].selected = false;
                            }
                            ListDragObj[i].Update(PositionTouch);
                        }
                    }
                } 
            }

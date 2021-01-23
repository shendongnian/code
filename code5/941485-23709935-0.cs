    <Image Width="200" Height="200" Margin="20">
      <Image.Source>
        <DrawingImage>
          <DrawingImage.Drawing>
            <DrawingGroup>
              <GeometryDrawing Brush="Black">
                <GeometryDrawing.Pen>
                  <Pen Brush="Black" />
                </GeometryDrawing.Pen>
                <GeometryDrawing.Geometry>
                  <PathGeometry>
                    <PathFigure StartPoint="100,100">
                      <PathFigure.Segments>
                        <LineSegment Point="100,0"/>
                        <ArcSegment Point="200,100"  SweepDirection="Clockwise" Size="100,100"/>
                        <LineSegment Point="100,100"/>
                      </PathFigure.Segments>
                    </PathFigure>
                  </PathGeometry>
                </GeometryDrawing.Geometry>
              </GeometryDrawing>
              <GeometryDrawing Brush="White">
                <GeometryDrawing.Pen>
                  <Pen Brush="Black"/>
                </GeometryDrawing.Pen>
                <GeometryDrawing.Geometry>
                  <PathGeometry>
                    <PathFigure StartPoint="200,100">
                      <PathFigure.Segments>
                        <ArcSegment Point="100,200" SweepDirection="Clockwise" Size="100,100"/>
                        <LineSegment Point="100,100"/>
                      </PathFigure.Segments>
                    </PathFigure>
                  </PathGeometry>
                </GeometryDrawing.Geometry>
              </GeometryDrawing>
              <GeometryDrawing Brush="Black">
                <GeometryDrawing.Pen>
                  <Pen Brush="Black"/>
                </GeometryDrawing.Pen>
                <GeometryDrawing.Geometry>
                  <PathGeometry>
                    <PathFigure StartPoint="100,100">
                      <PathFigure.Segments>
                        <LineSegment Point="100,200"/>
                        <ArcSegment Point="0,100" SweepDirection="Clockwise" Size="100,100"/>
                        <LineSegment Point="100,100"/>
                      </PathFigure.Segments>
                    </PathFigure>
                  </PathGeometry>
                </GeometryDrawing.Geometry>
              </GeometryDrawing>
              <GeometryDrawing Brush="White">
                <GeometryDrawing.Pen>
                  <Pen Brush="Black"/>
                </GeometryDrawing.Pen>
                <GeometryDrawing.Geometry>
                  <PathGeometry>
                    <PathFigure StartPoint="100,100">
                      <PathFigure.Segments>
                        <LineSegment Point="0,100"/>
                        <ArcSegment Point="100,0" SweepDirection="Clockwise" Size="100,100"/>
                      </PathFigure.Segments>
                    </PathFigure>
                  </PathGeometry>
                </GeometryDrawing.Geometry>
              </GeometryDrawing>
            </DrawingGroup>
          </DrawingImage.Drawing>
        </DrawingImage>
      </Image.Source>
    </Image>

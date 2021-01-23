    <Canvas x:Name="LayoutRoot" Background="White">
    <Image Source="/sam.png" MouseMove="Image_MouseMove" MouseLeave="Image_MouseLeave"/>
    <Popup Name="DeepZoomToolTip">
       <Border CornerRadius="1" Padding="1"   IsHitTestVisible="False">
           <TextBlock Text="Here is a tool tip" />
       </Border>
    </Popup>
    </Canvas>
    private void Image_MouseMove(object sender, MouseEventArgs e)
    {
        DeepZoomToolTip.IsOpen = true;
        DeepZoomToolTip.HorizontalOffset = e.GetPosition(LayoutRoot).X;
        DeepZoomToolTip.VerticalOffset = e.GetPosition(LayoutRoot).Y;
    }
    
    private void Image_MouseLeave(object sender, MouseEventArgs e)
    {
        DeepZoomToolTip.IsOpen = false;
    }

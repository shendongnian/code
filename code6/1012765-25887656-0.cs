    <ItemsControl ItemsSource="{Binding MyCollection}">
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Image Source="/Images/Fly.png">
                    <Image.RenderTransform>
                        <TransformGroup>
                            <RotateTransform Angle="{Binding Orientation}" />
                            <TranslateTransform X="{Binding Position.X}"
                                Y="{Binding Position.Y}" />
                        </TransformGroup>
                    </Image.RenderTransform>
                </Image>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>

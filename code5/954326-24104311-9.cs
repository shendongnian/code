        public void Update()
        {
            double dy = P2.Y - P1.Y;
            double dx = P2.X - P1.X;
            double theta = Math.Atan2(dy, dx);
            theta *= 180 / Math.PI;
            TransformAngle = theta; //remove the 90 degree vertial adjustment
            double aSq = Math.Pow(P1.X - P2.X, 2);
            double bSq = Math.Pow(P1.Y - P2.Y, 2);
            Length = Math.Sqrt(aSq + bSq);
        }
    <DataTemplate>
        <Grid>
            <Grid.RowDefinitions>
                <RowDefinition Height="auto"/>
                <RowDefinition Height="auto"/>
            </Grid.RowDefinitions>
            <Grid.RenderTransform>
                <RotateTransform Angle="{Binding TransformAngle}"/>
            </Grid.RenderTransform>
            <TextBlock Text="{Binding Label}" HorizontalAlignment="Center" ></TextBlock>
            <Line X2="{Binding Length}" Grid.Row="1" StrokeThickness="1" Stroke="Black"/>
        </Grid>
    </DataTemplate>

    public class CustomPieSeries : PieSeries
    {
        public ObservableCollection<ChartSegment> PieSegments { get; set; }
        public override void CreateSegments()
        {
            base.CreateSegments();
            PieSegments = Segments;
        }
    }
    <local:CustomPieSeries SegmentSelectionBrush="Cornsilk" ItemsSource="{Binding Expenditure}" XBindingPath="Expense" YBindingPath="Amount"   EnableAnimation="True" PieCoefficient="0.6"  ExplodeRadius="20"   x:Name="pieSeries" ShowTooltip="True" chart:ChartTooltip.EnableAnimation="True"  Label="" LabelPosition="Outside"   Palette="Custom">
                <local:CustomPieSeries.ColorModel>
                    <chart:ChartColorModel>

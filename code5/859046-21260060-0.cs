    // DevicesPanel.cs
    public class DevicesPanel : Canvas
    {
        public List<string> Data { get; set; }
    }
    // MainWindow.xaml
    <wpfApplication1:DevicesPanel>
        <wpfApplication1:DevicesPanel.Data>
            <system:String>Item1</system:String>
            <system:String>Item2</system:String>
            <system:String>Item3</system:String>
        </wpfApplication1:DevicesPanel.Data>
    </wpfApplication1:DevicesPanel>

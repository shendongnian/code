    public class WaterTextBox : TextBox
    {        
        protected override IEnumerator LogicalChildren
        {
            get
            {
                ArrayList list = new ArrayList();
                list.Add(WatermarkService.GetWatermark(this));
                return (IEnumerator)list.GetEnumerator();
            }
        }
    }

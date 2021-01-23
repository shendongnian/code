    public class WaterTextBox : TextBox
    {        
        protected override IEnumerator LogicalChildren
        {
            get
            {
                ArrayList list = new ArrayList();
                IEnumerator enumerator = base.LogicalChildren;
                while (enumerator.MoveNext())
                {
                    list.Add(enumerator.Current);
                }
                object watermark = WatermarkService.GetWatermark(this);
                if (watermark != null && !list.Contains(watermark))
                {
                    list.Add(WatermarkService.GetWatermark(this));
                }
                return (IEnumerator)list.GetEnumerator();
            }
        }
    }

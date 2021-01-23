    public class Rtb
    {
        private static int _NextID = -1;
        public static int NextID
        {
            get
            {
                _NextID++;
                return _NextID;
            }
        }        
        public RichTextBox newRTB;
        public Rtb()
        {
            newRTB = new RichTextBox();
            newRTB.IsReadOnly = true;
            newRTB.MouseDoubleClick += new MouseButtonEventHandler(newRTB_MouseDoubleClick);
            newRTB.Name = "Box" + NextID.ToString();
        }
    }

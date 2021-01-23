    private KeyMessageFilter _filter = new KeyMessageFilter();
    
    private void Form1_Load(object sender, EventArgs e)
    {
        Application.AddMessageFilter(_filter);    
    }    
    
    public class KeyMessageFilter : IMessageFilter
    {
        private Dictionary<Keys, bool> _keyTable = new Dictionary<Keys, bool>();
    
        public Dictionary<Keys, bool> KeyTable
        {
            get { return _keyTable; }
            private set { _keyTable = value; }
        }
    
        public bool IsKeyPressed()
        {
            return _keyPressed; 
        }
    
        public bool IsKeyPressed(Keys k)
        {
            bool pressed = false;
    
            if (KeyTable.TryGetValue(k, out pressed))
            {
                return pressed;                  
            }
    
            return false; 
        }
    
        private const int WM_KEYDOWN = 0x0100;
    
        private const int WM_KEYUP = 0x0101;
    
        private bool _keyPressed = false;
    
    
        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == WM_KEYDOWN)
            {
                KeyTable[(Keys)m.WParam] = true;
    
                _keyPressed = true;
            }
    
            if (m.Msg == WM_KEYUP)
            {                
                KeyTable[(Keys)m.WParam] = false;
    
                _keyPressed = false;
            }
    
            return false;        
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Dictionary<string, EventHandler> _handlers = new Dictionary<string, EventHandler>();
        TextBox _txt = new TextBox();
       
        void WireHandlers()
        {
            
             EventHandler _hnd1 = delegate { return; };
             EventHandler _hnd2 = delegate { return; };
            
            _txt.Click += _hnd1;
            _txt.TextChanged  += _hnd2;
            _handlers.Add("Click", _hnd1);
            _handlers.Add("TextChanged", _hnd2);
        }
        void UnwireHandlers()
        {
            foreach (var kvp in _handlers)
            {
                switch (kvp.Key)
                {
                    case "Click":
                        _txt.Click -= kvp.Value;
                        break;
                    case "TextChanged":
                        _txt.TextChanged  -= kvp.Value;
                        break;
                    default:
                        throw new Exception("no such handler found");
                }
            }
            
        }
    }

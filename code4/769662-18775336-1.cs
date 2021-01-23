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
            
             // get references of your handlers
             EventHandler _hnd1 = delegate { return; }; // here will be your named method. This is only for example
             EventHandler _hnd2 = delegate { return; }; // here will be your named method. This is only for example
            
             // wire handlers
            _txt.Click += _hnd1;
            _txt.TextChanged  += _hnd2;
             // save wired handler collection
            _handlers.Add("Click", _hnd1);
            _handlers.Add("TextChanged", _hnd2);
        }
        void UnwireHandlers()
        {
            // lets unwire all handlers
            foreach (var kvp in _handlers)
            {
                // inspect keyValuePair - each key corresponds to the name of some event
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
            _handlers.Clear();
        }
    }

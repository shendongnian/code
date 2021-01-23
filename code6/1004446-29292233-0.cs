        private static PseudoEventManager _instance = new PseudoEventManager();
        private readonly Dictionary<object, List<object>> _handlerTable 
                                 = new Dictionary<object, List<object>>();
    
        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
 	        foreach (var handler in _handlerTable[sender]) // point of interest A
                //invoke handler
        }
        public static void AddHandler(object source, object handler)
        {
            if (!_instance._handlerTable.ContainsKey(source)) 
                _instance._handlerTable.Add(source, new List<object>()); //point of interest B
            _instance._handlerTable[source].Add(handler);
            //attach to event
        }
    }

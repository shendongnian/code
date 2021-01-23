    public string LastMessage;
    
    private KinectReader _kinectReader;
    private volatile Stack<string> _messageStack;
	// Use this for initialization
	void Start () 
    {
        _messageStack = new Stack<string>();
	    LastMessage = "";
        // init Kinect Reader
        _kinectReader = new KinectReader();
        _kinectReader.StartPipeReader();
        _kinectReader.KinectHandler += _kinectReader_KinectHandler;
	}
    void _kinectReader_KinectHandler(string message)
    {
        _messageStack.Push(message);
    }
	
	// Update is called once per frame
	void Update () 
    {
        // Update Last message
	    while (_messageStack.Any())
	    {
	        LastMessage = _messageStack.Pop();
            Debug.Log(LastMessage);
	    }
	}
    void OnApplicationQuit()
    {
        Debug.Log("Stoping the pipe client");
        _kinectReader.Stop();
        Debug.Log("Qutting application");
    }

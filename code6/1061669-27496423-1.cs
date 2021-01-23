    public Course
    {
    	// Course code
    	private string _code;
    	public string Code
    	{
    		get { return this._code; }
    		set { this._code = value; }
    	}
    
    	// Course Name
    	private string _name;
    	public string Name
    	{
    		get { return this._name; }
    		set { this._name = value; }
    	}
    	
    	// A course has many peers
    	private List<Peer> _peers;
    	public List<Peer> Peers
    	{
    		get { return this._peers; }
    		set { this._peers = value; }
    	}
    	
    	// A new course is always instantiated with a new empty list of peers.
    	public Course()
    	{
    		this._peers = new List<Peer>();
    	}
    	
    	// A course can be instantiated with a course name and code
    	public Course(string name, string code)
    		: base()
    	{
    		this._name = name;
    		this._code = code;
    	}
    	
    	// A course can have a peer added
    	public void AddPeer(Peer peer)
    	{
    		this._peers.Add(peer);
    	}
    	
    	// A course average can be calculated
    	public double GetCourseAverage()
    	{
    		int peerCount = this._peers.Count();
    		double totalScores = 0;
    		
    		foreach (var peer in this.peers)
    			totalScores += peer.Evaluate();
    
                // Prevent DivideByZeroException from being thrown
                if (totalScores == 0)
                     return 0;
    			
    		return totalScores / peerCount;
    	}
    }
    
    public Peer
    {
    	// Peer name
    	private string _name;
    	public string Name
    	{
    		get { return this._name; }
    		set { this._name = value; }
    	}
    	
    	// A peer has a list of scores
    	private List<Score> _scores;
    	
    	// A new peer is always instantiated with a new empty list of scores.
    	public Peer()
    	{
    		this._scores = new List<Score>();
    	}
    	
    	// A new peer can be instantiated with his or her name
    	public Peer(string name)
    		: base();
    	{
    		this._name = name;
    	}
    	
    	// A score can be added to a peer's list of scores
    	public void AddScore(Score score)
    	{
    		if (score != null)
    			this._scores.Add(score);
    	}
    	
    	// A peer an be evaluated
    	public double Evaluate()
    	{
    		// Do your if evaluation conditions in here
    		// if score.Value > 1, etc.
    		double result = 0;
    		foreach (var score in this._scores)
    			result += score.Value;
    		
    		return result;
    	}
    }
    
    public Score
    {
    	private double _value;
    	public double Value
    	{
    		get { return this._value; }
    		set { this._value = value; }
    	}
    
    	public Score()
    	{
    		// Nothing to initialize 
    	}
    	
    	// A score can be initialized with a value
    	public Score(double value)
    		: base()
    	{
    		this._value = value;
    	}
    }
    
    static int Main(string[] args)
    {  	
    	private _courseName = "Science";
    	private _courseCode = "SCI123";
    	private _peerName = "Sam";
    
    	// Create a course
    	private Course _course = new Course(_courseName, _courseCode);
    	
    	// Add a peer called Sam
    	_courses.AddPeer(new Peer(peerName);
    	
    	// Find sam and add a score
    	if ((found = _courses.FirstOrDefault(peer => peer.Name = peerName) != null)
    	{
    		// Sam was found, lets add a few scores for sam
    		found.Scores.Add(new Score(0.9));
    		found.Scores.Add(new Score(0.8));
    		found.Scores.Add(new Score(0.5));
    		found.Scores.Add(new Score(0.7));
    		found.Scores.Add(new Score(0.8));
    		
    		// Lets evaluate Sam
    		var result = found.Evaluate();
    		Console.WriteLine(string.Format("{0} total score was {1}.", found.Name, result));
    	}
    }

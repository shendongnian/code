    private string[] _allLines;
    private int _linesRead;
    void Start() { 
        _linesRead = 0;
        var savedDoc = File.OpenText("C:/KleindierparkAdministratie/voer/voer.txt");
        _allLines = savedDoc.ReadAllLines();
    }
    void OnGUI() {
        if (/* Button pressed*/) {
        // read next line and do stuff
        }
    }

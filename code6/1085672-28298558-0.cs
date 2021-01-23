	string stringtoedit = " ";
	int voercounter = 0;
	TextReader saveddoc;
	string line;
	void Start(){
		saveddoc = File.OpenText("C:/KleindierparkAdministratie/voer/voer.txt");
		line = saveddoc.ReadLine();
	}
	void OnGUI(){
		GUI.Label (new Rect (10, 10, 100, 20), line);
		stringtoedit = GUI.TextField(new Rect(100, 10, 200, 20), stringtoedit, 25);
		var voerdoc = File.OpenText("C:/KleindierparkAdministratie/voer/" + line + ".txt");
		var line2 = voerdoc.ReadLine();
		int counter = 1;
		while(line2 != null){
			if(counter == 5){
				GUI.Label(new Rect(350, 10, 100, 20), line2);
			}
			
			counter++;
			line2 = voerdoc.ReadLine();
		}
		
		if (GUI.Button (new Rect (25, 50, 250, 30), "Next")) {
			
			line = saveddoc.ReadLine();
			Debug.Log (line);
			
		}	
		
	}
	

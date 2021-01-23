    using UnityEngine;
    using System.Collections;
    using System.IO;
    public class bestellen : MonoBehaviour {
        string stringtoedit = " ";
        int voercounter = 0;
        string line = "";
        string line2 = "";
        var saveddoc;
        void Start()
        {
            saveddoc = File.OpenText("C:/KleindierparkAdministratie/voer/voer.txt");
        }
        void OnGUI(){
            GUI.Label (new Rect (10, 10, 100, 20), line);
            stringtoedit = GUI.TextField(new Rect(100, 10, 200, 20), stringtoedit, 25);
            GUI.Label(new Rect(350, 10, 100, 20), line2);
            if (GUI.Button (new Rect (25, 50, 250, 30), "Next")) {
                line = saveddoc.ReadLine();
                Debug.Log (line);
                var voerdoc = File.OpenText("C:/KleindierparkAdministratie/voer/" + line + ".txt");
                var lineTemp = voerdoc.ReadLine();
                int counter = 1;
                // in this loop you are reading the whole document just to keep the 5th line.
                // Consider refactor the loop just to read the desired line
                while(lineTemp != null){
                    if(counter == 5){
                        line2 = lineTemp;
                    }
                    counter++;
                    lineTemp = voerdoc.ReadLine();
                }
                // Close here voerdoc!!!!
            }   
        }
    }

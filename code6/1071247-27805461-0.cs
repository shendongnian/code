    using UnityEngine;
    using System.Collections;
    using UnityEditor;
    using System.IO;
    using System.Text.RegularExpressions;
    public class CharacterCreatorEditor : EditorWindow {
	    #region Character Fields
	    //Add as many character specific fields / variables you want here.
	    //Remember to update the same thing in the "CharacterTemplate.txt"!
	    public string characterName = "John Doe";
	    public float characterHealth = 10;
	    public int characterCost = 1000;
	    public bool isBadGuy = false;
	    #endregion
	    private bool needToAttach = false;		//A boolean that checks whether a newly created script has to be attached
	    private float waitForCompile = 1;		//Counter for compile
	    GameObject tempCharacter;				//A temporary GameObject that we assign the new chracter to.
	    //A Menu Item when clicked will bring up the Editor Window
	    [MenuItem ("AxS/Create New Character")]
	    public static void CreateNewChar () {
		     EditorWindow.GetWindow(typeof(CharacterCreatorEditor));
	    }
	    void OnGUI () {
		    GUILayout.Label("Here's a sample Editor Window. Put in more variables as you need below.");
		    GUILayout.Space(10);
		    //Note on adding more fields
		    //The code below is broken into groups, one group per variable
		    //While it's relatively long, it keeps the Editor Window clean
		    //Most of the code should be fairly obvious
		    GUILayout.BeginHorizontal();
		    GUILayout.Label("Character Name", new GUILayoutOption[0]);
		    characterName = EditorGUILayout.TextField(characterName, new GUILayoutOption[0]);
		    GUILayout.EndHorizontal();
		    GUILayout.Space(10);
		    GUILayout.BeginHorizontal();
		    GUILayout.Label("Character Health", new GUILayoutOption[0]);
		    characterHealth = EditorGUILayout.FloatField(characterHealth, new GUILayoutOption[0]);
		    GUILayout.EndHorizontal();
		    GUILayout.Space(10);
		    GUILayout.BeginHorizontal();
		    GUILayout.Label("Character Cost", new GUILayoutOption[0]);
	    	characterCost = EditorGUILayout.IntField(characterCost, new GUILayoutOption[0]);
		    GUILayout.EndHorizontal();
		    GUILayout.Space(10);
		    GUILayout.BeginHorizontal();
		    GUILayout.Label(string.Format("Is {0} a Bad Guy?", new object[] { characterName }), new GUILayoutOption[0]);
		    isBadGuy = EditorGUILayout.Toggle(isBadGuy, new GUILayoutOption[0]);
		    GUILayout.EndHorizontal();
		    GUILayout.Space(10);
		    GUI.color = Color.green;
		    //If we click on the "Done!" button, let's create a new character
		    if(GUILayout.Button("Done!", new GUILayoutOption[0]))
			    CreateANewCharacter();
	    }
	    void Update () {
		    //We created a new script below (See the last few lines of CreateANewCharacter() )
		    if(needToAttach) {
			    //Some counter we just keep reducing, so we can give the
			    //EditorApplication.isCompiling to kick in
			    waitForCompile -= 0.01f;
			    //So a few frames later, we can assume that the Editor has enough
			    //time to "catch up" and EditorApplication.isCompiling will now be true
			    //so, we wait for the newly created script to compile
			    if(waitForCompile <= 0) {
				     //The newly created script is done compiling
				    if(!EditorApplication.isCompiling) {
					    //Lets add the script
					    //Here we add the script using the name as a string rather than
					    //it's type in Angled braces (As done below)
					    tempCharacter.AddComponent(characterName.Replace(" ", ""));
					    //Reset the control variables for attaching these scripts.
					    needToAttach = false;
					    waitForCompile = 1;
				    }
			    }
		     }
	    }
	    private void CreateANewCharacter () {
		    //Instantiate a new GameObject
		    tempCharacter = new GameObject();
		    //Name it the same as the Character Name 
		    tempCharacter.name = characterName;
		    //Add the ChracterScript component. Note the use of angle braces over quotes
		    tempCharacter.AddComponent<CharacterScript>();
		    //Loading the template text file which has some code already in it.
		    //Note that the text file is stored in the path PROJECT_NAME/Assets/CharacterTemplate.txt
		    TextAsset templateTextFile = AssetDatabase.LoadAssetAtPath("Assets/CharacterTemplate.txt", 
		                                                           typeof(TextAsset)) as TextAsset;
		    string contents = "";
		    //If the text file is available, lets get the text in it
		    //And start replacing the place holder data in it with the 
		    //options we created in the editor window
		    if(templateTextFile != null) {
			    contents = templateTextFile.text;
			    contents = contents.Replace("CHARACTERCLASS_NAME_HERE", characterName.Replace(" ", ""));
			     contents = contents.Replace("CHARACTER_NAME_HERE", characterName);
			    contents = contents.Replace("CHARACTER_HEALTH_HERE", characterHealth.ToString());
			    contents = contents.Replace("CHARACTER_COST_HERE", characterCost.ToString());
			    contents = contents.Replace("CHARACTER_BAD_GUY_HERE", isBadGuy.ToString().ToLower());
		    }
		    else {
			    Debug.LogError("Can't find the CharacterTemplate.txt file! Is it at the path YOUR_PROJECT/Assets/CharacterTemplate.txt?");
		    }
		    //Let's create a new Script named "CHARACTERNAME.cs"
		    using(StreamWriter sw = new StreamWriter(string.Format(Application.dataPath + "/{0}.cs", 
		                                                       new object[] { characterName.Replace(" ", "") }))) {
			    sw.Write(contents);
		    }
		    //Refresh the Asset Database
		    AssetDatabase.Refresh();
		    //Now we need to attach the newly created script
		    //We can use EditorApplication.isCompiling, but it doesn't seem to kick in
		    //after a few frames after creating the script. So, I've created a roundabout way
		    //to do so. Please see the Update function
		    needToAttach = true;
	    }
    }

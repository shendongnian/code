      using UnityEngine;
      using System.Collections;
      public class MoveToRandomScene : MonoBehaviour {
      public Texture nextButtonTexture; // set this in the inspector 
	  public static int[] arrScenes;
	  public static int index;
	  void Start () {
		index = 0;
		arrScenes = GenerateUniqueRandom (10, 0, 10); //assuming you have 10 levels starting from 0.
	}
	void OnGUI {
    // Load the first element of the array
        if (GUI.Button(new Rect (0,0,Screen.width/4,Screen.height/4),nextButtonTexture))
        {
		int level = arrScenes [0] ;
		Application.LoadLevel (level);
        }
	}
    //Generate unique numbers (levels) in an array
	public int[] GenerateUniqueRandom(int amount, int min, int max)
	{
		int[] arr = new int[amount];
		for (int i = 0; i < amount; i++)
		{
			bool done = false;
			while (!done)
			{
				int num = Random.Range(min, max);
				int j = 0;
				for (j = 0; j < i; j++)
				{
					if (num == arr[j])
					{
						break;    
					}
				}
				if (j == i)
				{
					arr[i] = num;
					done = true;
				}
			}
		}
		return arr;
	}

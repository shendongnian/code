	public class HungerClass : MonoBehaviour {
		int Hunger = 100;
		
		IEnumerator Start () 
		{
			while (true)
			{
				//Every ten seconds Hunger goes down by one.
				Hunger = Hunger - 1;
				yield return  new WaitForSeconds(10);	
			}
		}
		void OnGUI()
		{
			GUI.Label(new Rect (10,40,100,20), "Hunger = " + Hunger);
		}
	}

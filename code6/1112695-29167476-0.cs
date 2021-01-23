    using UnityEngine;
    using UnityEngine.UI;
    public class FlappyScore : MonoBehaviour{
    // Add the Above if you still haven't cause the Text class that you will need is in there, in UnityEngine.UI;
    public Text MyScore;
    // Go back to Unity and Drag the "text" GameObject in your canvas to this script.
    void Start(){
     /* if Having difficulty with the above instruction. Un comment this comment block.
    MyScore = GameObject.Find("text").GetComponent<Text>();
    */
      MyScore.text = "50";
     // Your score needs to be casted to a string type.
     }
}

    using UnityEngine;
    using System.Collections;
    using Leap;
    public class LeapTest : Leap.Listener {
        public Leap.Controller Controller;
        // Use this for initialization
        public void Start () {
            Controller = new Leap.Controller(this);
            Debug.Log("Leap start");
        }
	
        public override void OnConnect(Controller controller){
            Debug.Log("Leap Connected");
            controller.EnableGesture(Gesture.GestureType.TYPECIRCLE,true);
        }
        public override void OnFrame(Controller controller)
        {
            Frame frame = controller.Frame();
            GestureList gestures = frame.Gestures();
            for (int i = 0; i < gestures.Count; i++)
            {
                Gesture gesture = gestures[0];
                switch(gesture.Type){
                    case Gesture.GestureType.TYPECIRCLE:
                        Debug.Log("Circle");
                        break;
                    default:
                        Debug.Log("Bad gesture type");
                        break;
                }
            }
        }
    }

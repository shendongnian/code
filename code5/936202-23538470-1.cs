    class HandController : MonoBehaviour
    {
        bool m_Tracked;
        Color NotDetected { get { return Color.red; } }
        Color Detected { get { return new Color(189/255.0f, 165/255.0f, 134/255.0f); } }
    
        public bool Tracked
        {
            if (m_Tracked == value) return;
            m_Tracked = value;
            renderer.material.color = value ? Detected : NotDetected;
        }
    }
    
    // ...
    
    LeftHand.Tracked = LeftHandTracked;
    if (TappedFingers.Length != FINGERS*2)
    {
        Debug.LogError("Unexpected amount of fingers: " + TappedFingers.Length);
        return;
    }
    for(int i = 0; i < FINGERS; i++)
    {    
        LeftHand.SetSide(TappedFingers[i], i);
    }
    for(int i = FINGERS; i < FINGERS*2; i++)
    {    
        RightHand.SetSide(TappedFingers[i], i-FINGERS);
    }

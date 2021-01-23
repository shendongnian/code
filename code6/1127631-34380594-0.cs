    using UnityEngine;
    using UnityEngine.UI;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using UnityEngine.Events;
    using System;
    using UnityEngine.EventSystems;
    using UnityEngine.Serialization;
    public class SubmitInputField : InputField
    {
	    [Serializable]
	    public class KeyboardDoneEvent : UnityEvent{}
	    [SerializeField]
	    private KeyboardDoneEvent m_keyboardDone = new KeyboardDoneEvent ();
	    public KeyboardDoneEvent onKeyboardDone {
		    get { return m_keyboardDone; }
		    set { m_keyboardDone = value; }
	    }
	    void Update ()
	    {
		    if (m_Keyboard != null && m_Keyboard.done && !m_Keyboard.wasCanceled) {
		    	m_keyboardDone.Invoke ();
	    	}
    	}
    }

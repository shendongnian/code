    using UnityEngine;
    using System.Collections;
    using System;
    using System.Runtime.InteropServices;
    
    public class PluginImport : MonoBehaviour
    {
        //Lets make our calls from the Plugin
        [DllImport("MathAssistant", EntryPoint = "?addition@ma@@YAMMM@Z")]
        private static extern float addition(float val_1, float val_2);
        [DllImport("MathAssistant", EntryPoint = "?substraction@ma@@YAMMM@Z")]
    	private static extern float substraction(float val_1, float val_2);
        [DllImport("MathAssistant", EntryPoint = "?multiplication@ma@@YAMMM@Z")]
    	private static extern float multiplication(float val_1, float val_2);
        [DllImport("MathAssistant", EntryPoint = "?division@ma@@YAMMM@Z")]
    	private static extern float division(float val_1, float val_2);
    
        void Start()
        {
            Debug.Log(addition(5, 5));
            Debug.Log(substraction(10, 5));
            Debug.Log(multiplication(2, 5));
            Debug.Log(division(10, 2));
        }
    }

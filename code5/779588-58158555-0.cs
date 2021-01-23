    using System;
    using System.Collections.Generic;
    using System.Threading;
    using UnityEngine;
    
    public class ThreadTest : MonoBehaviour
    {
        private List<int> numbers = null;
    
        private void Start()
        {
            Debug.Log("1. Call thread task");
    
            StartMyLongRunningTask();
    
            Debug.Log("2. Do something else");
        }
    
        private void StartMyLongRunningTask()
        {
            numbers = new List<int>();
    
            ThreadStart starter = myLongRunningTask;
    
            starter += () =>
            {
                myLongRunningTaskDone();
            };
    
            Thread _thread = new Thread(starter) { IsBackground = true };
            _thread.Start();
        }
    
        private void myLongRunningTaskDone()
        {
            Debug.Log("3. Task callback result");
    
            foreach (int num in numbers)
                Debug.Log(num);
        }
    
    
        private void myLongRunningTask()
        {
            for (int i = 0; i < 10; i++)
            {
                numbers.Add(i);
    
                Thread.Sleep(1000);
            }
        }
    }

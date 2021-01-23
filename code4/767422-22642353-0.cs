    using UnityEngine;
    using System.Collections.Generic;
    
    public class ForeachTest : MonoBehaviour 
    {
    	private string _testString = "this is a test";
    	private List<string> _testList;
    	private const int _numIterations = 10000;
    
        void Start()
        {
    		_testList = new List<string>();
    		for(int i = 0; i < _numIterations; ++i)
    		{
    			_testList.Add(_testString);
    		}
        }
        
        void Update()
        {
        	ForeachIter();
    	}
    
    	private void ForeachIter()
    	{
    		string s;
    
    		for(int i = 0; i < 1000; ++i)
    		{
    			foreach(string str in _testList)
    			{
    				s = str;
    			}
    		}
    	}
    }

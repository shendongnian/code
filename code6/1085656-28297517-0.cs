    class ClassA
    {
        private void myMthod()
        {
            MyClassB myClassB = new ClasB();
            CustomObject myCustomObject = new CustomObject();
            myClassB.MyMethodOnClassB(ref myCustomObject);
    
            if(miCustomObject == null)
            {
                 //code in case of null
            }
            else
            {
                //code in case of not null
            }
        }
    }
    
    
    class ClassB
    {
        CustomObject _myCustomObjectOnB;
    
        public ClassB(CustomObject paramCustomObject)
        {
            _myCustomObjectOnB = paramCustomObject;
        }
    
        public MyMethodOnClassB(ref CustomObject customObject)
        {
            _myCustomObject = customObject = null;
        }
    }

        public class MyFunctionResult
        {
            public readonly float MyFloat;
            public readonly string MyString;
            public readonly int MyInt;
            public MyFunctionResult(float myFloat, string myString, int myInt)
            {
                MyFloat = myFloat;
                MyString = myString;
                MyInt = myInt;
            }
        }
        void OnGUI()
        {
            float myFloat = 1;
            string myString = "";
            int myInt = 2;
            var finalResult = myFunction(myFloat, myString, myInt);
            Debug.Log(finalResult.MyFloat); //...
        }
        //First Function
        public MyFunctionResult myFunction(float myFloat, string myString, int myInt)
        {
            //Do something
            var myOtherFunctionResult = myOtherFunction(myFloat, myString, myInt);
            float myFloatResult = myOtherFunctionResult.MyFloat;
            string myStringResult = myOtherFunctionResult.MyString;
            int myIntResult = myOtherFunctionResult.MyInt;
            //Do something
            return new MyFunctionResult(myFloat, myString, myInt);
        }
        //Second function
        public MyFunctionResult myOtherFunction(float myFloat, string myString, int myInt)
        {
            //Do something
            return new MyFunctionResult(myFloat, myString, myInt);
        }

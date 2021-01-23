    using System;
    using System.Reflection;
    using System.IO;
    using System.Collections.Generic;
    using System.Text;
    
    class Program
    {
        static void Main(string[] args)
        {
            MyClass mC= new MyClass();
            string result = mC.ToString();
        }
    }
    
    class MyClass
    {
        string someValue = "One";
        int someValue1 = -1;
        bool someValue2 = false;
        float someValue3 = 2.2f;
    
        public string SomeValue
        {
            get{ return this.someValue;}
        }
    
        public int SomeValue1
        {
            get { return this.someValue1; }
        }
    
        public bool SomeValue2
        {
            get { return this.someValue2; }
        }
    
        public float SomeValue3
        {
            get { return this.someValue3; }
        }
    
        public override string ToString()
        {
            string result = string.Empty;
            Type type = this.GetType();
            PropertyInfo [] pInfo = type.GetProperties();
            
            for (int i = 0; i <= pInfo.Length-1; i++)
            {
                Type internalType = this.GetType();
                PropertyInfo pInfoObject = internalType.GetProperty(pInfo[i].Name);
                object value = pInfoObject.GetValue(this,null);
                result += pInfo[i].Name + " : " + value.ToString() + System.Environment.NewLine;
            }
            return result;
        }
    }

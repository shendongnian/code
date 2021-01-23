        using UnityEngine;
            using System.Collections;
            using System;
            [Serializable]
            public class MyClass 
            {
                public static MyClass saveObj;
                public  int width = 0;
                public  int height = 0;
    }
        //(please use another script to perform these saving and loading operations):
    
        
        public void Save()
        {
            MyClass obj = new MyClass();
            obj.width = 100;
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create ("stuff.dat");
            bf.Serialize(file, obj);
            file.Close();
        }
    
        public void Load()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open("stuff.dat");
            MyClass.saveObj = (MyClass)bf.Deserialize(file);
            file.Close();
            print(MyClass.saveObj.width);
        }

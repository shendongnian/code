    using System.IO;
    using System;
    using System.Collections.Generic;
    
    public class ArrayWithBackup : List<String>
    {
        List<String> arrayWithBackup;
        List<String> backupArray;
        public ArrayWithBackup()
        {
            arrayWithBackup = new List<string>();
        }
    
        public void AddStrings(List<String> inputs)
        {
            if (backupArray != null && backupArray.Count > 0)
                backupArray.Clear();
    
            backupArray = new List<string>(arrayWithBackup);
            arrayWithBackup.Clear();
            for (int i = 0; i < inputs.Count; ++i)
            {
                arrayWithBackup.Add(inputs[i]);
            }
        }
    
        public void PrintArray()
        {
            Console.WriteLine("Array contains:");
            for(int i = 0; i < arrayWithBackup.Count; ++i)
                Console.WriteLine("Index {0}: {1}", i, arrayWithBackup[i]);
        }
    
        public void PrintBackupArray()
        {
            Console.WriteLine("BackupArray contains:");
            for (int i = 0; i < backupArray.Count; ++i)
                Console.WriteLine("Index {0}: {1}", i, backupArray[i]);
        }
    
        public List<String> GetArray()
        {
            return arrayWithBackup;
        }
    
        public List<String> GetBackupArray()
        {
            return backupArray;
        }
    }
    public class Test
    {
        static void Main(string[] args)
        {
            ArrayWithBackup awb = new ArrayWithBackup();
    
            List<String> inputs = new List<String>();
            inputs.Add("one");
            inputs.Add("two");
            inputs.Add("three");
    
            awb.AddStrings(inputs);
            inputs.Clear();
    
            inputs.Add("four");
            inputs.Add("five");
            inputs.Add("six");
            awb.AddStrings(inputs);
    
            awb.PrintArray();
            awb.PrintBackupArray();
        }
    }
    //Output:
    //Array contains:
    //Index 0: four
    //Index 1: five
    //Index 2: six
    
    //BackupArray contains:
    //Index 0: one
    //Index 1: two
    //Index 2: three

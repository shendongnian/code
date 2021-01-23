        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Runtime.InteropServices;
        
        namespace CPP_Library_To_NET
        {
            class Program
            {
                [DllImport("Testlib.dll", CallingConvention = CallingConvention.Cdecl)]
                public static extern bool SQLite_CreateTable([MarshalAs(UnmanagedType.LPStr)]string dbPath, 
                                                             [MarshalAs(UnmanagedType.LPStr)]string tableName,
                                                             [MarshalAs(UnmanagedType.LPStr)]string fieldList);
                
                //Try to add DLLImport again like below, see if it works
                [DllImport("Testlib.dll", CallingConvention = CallingConvention.Cdecl)]
                public static extern bool SQLite_ImportCSV([MarshalAs(UnmanagedType.LPStr)]string dbPath,
                                                           [MarshalAs(UnmanagedType.LPStr)]string csvPath,
                                                           [MarshalAs(UnmanagedType.LPStr)]string tableName);
        
                static void Main(string[] args)
                {
                    // some variable initialisations...
        
                    // Create table
                    ret = SQLite_CreateTable(path, tableName, fieldList);
        
                    if (!ret) { Console.WriteLine("Failed to create table " + tableName); }
                    else { Console.WriteLine("Successfully created table " + tableName); }
        
                    // Importing CSV data...
                    ret = SQLite_ImportCSV(path, csvPath, "TestTab");
        
                    if (!ret) { Console.WriteLine("Failed to import csv " + csvPath); }
                    else { Console.WriteLine("Successfully imported csv " + csvPath); }
        
                    Console.ReadLine();
                }
            }
        }

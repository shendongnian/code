    using Microsoft.VisualBasic;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Collections.ObjectModel;
    
    class MainWindow
    {
    
    
    	public ObservableCollection<MyObject> MyObjectCollection = new ObservableCollection<MyObject>();
    
    	public MainWindow()
    	{
    		// This call is required by the designer.
    		InitializeComponent();
    
    		// Add any initialization after the InitializeComponent() call.
    		for (i = 1; i <= 10; i++) {
    			MyObject newObject = new MyObject {
    				age = i,
    				name = "Full Name"
    			};
    			MyObjectCollection.Add(newObject);
    		}
    
    
    		MyDataGrid.ItemsSource = MyObjectCollection;
    	}
    }
    
    public class MyObject
    {
    	public string name { get; set; }
    	public string age { get; set; }
    }

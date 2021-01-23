    using Microsoft.VisualBasic;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    public class Form1
    {
    
    	public void Zip()
    	{
    		//1) Lets create an empty Zip File .
    		//The following data represents an empty zip file .
    
    		byte[] startBuffer = {
    			80,
    			75,
    			5,
    			6,
    			0,
    			0,
    			0,
    			0,
    			0,
    			0,
    			0,
    			0,
    			0,
    			0,
    			0,
    			0,
    			0,
    			0,
    			0,
    			0,
    			0,
    			0
    		};
    		// Data for an empty zip file .
    		FileIO.FileSystem.WriteAllBytes("d:\\empty.zip", startBuffer, false);
    
    		//We have successfully made the empty zip file .
    
    		//2) Use the Shell32 to zip your files .
    		// Declare new shell class
    		Shell32.Shell sc = new Shell32.Shell();
    		//Declare the folder which contains the files you want to zip .
    		Shell32.Folder input = sc.NameSpace("D:\\neededFiles");
    		//Declare  your created empty zip file as folder  .
    		Shell32.Folder output = sc.NameSpace("D:\\empty.zip");
    		//Copy the files into the empty zip file using the CopyHere command .
    		output.CopyHere(input.Items, 4);
    
    	}
    
    	public void UnZip()
    	{
    		Shell32.Shell sc = new Shell32.Shell();
    		//'UPDATE !!
    		//Create directory in which you will unzip your files .
    		IO.Directory.CreateDirectory("D:\\extractedFiles");
    		//Declare the folder where the files will be extracted
    		Shell32.Folder output = sc.NameSpace("D:\\extractedFiles");
    		//Declare your input zip file as folder  .
    		Shell32.Folder input = sc.NameSpace("d:\\myzip.zip");
    		//Extract the files from the zip file using the CopyHere command .
    		output.CopyHere(input.Items, 4);
    
    	}
    
    }

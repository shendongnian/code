    using System;
    using Android.App;
    using Android.OS;
    namespace App1 {
    [Activity(Label = "Unknown Identifier Test", MainLauncher = true)]
    public class MainActivity : Activity {        
        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);
            Console.WriteLine(MyClass.MyString);            // Unqualified
            Console.WriteLine(App1.MyClass.MyString);       // Fully Qualified with namespace
            /*
            Set a break point on the "Console.WriteLine()" lines above and you'll get the 
            "Unknown identifier: MyClass" error when trying to inspect under specific conditions...
            File Locations                                      Unqualified             Fully Qualified
            -------------------------------------------------   ---------------------   --------------------
            MainActivity.cs in root, MyClass.cs in sub-folder   "Unknown identifier"    Inspection Works
            MainActivity.cs in sub-folder, MyClass.cs in root   Inspection Works        Inspection Works
            Both in root                                        Inspection Works        Inspection Works
            Both in different sub-folders                       "Unknown identifier"    "Unknown identifier"
            Both in same sub-folder                             "Unknown identifier"    "Unknown identifier"
            */
        }
    }
    }

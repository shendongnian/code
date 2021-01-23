        namespace check
        {    
           public partial class MainPage : UserControl
           {
                public MainPage()
                {
                    InitializeComponent();
        	        // Use the generic type Test with an int type parameter.
        	        Test<int> Test1 = new Test<int>(5);
        	        // Call the Write method.
        	        Test1.Write();
        
        	        // Use the generic type Test with a string type parameter.
        	        Test<string> Test2 = new Test<string>("cat");
        	        Test2.Write();
                }
           }
        
           class Test<T>
           {
               T _value;    
               public Test(T t)
               {
        	      // The field has the same type as the parameter.
        	      this._value = t;
               }    
               public void Write()
               {
        	      MessageBox.Show(this._value);
               }
           }
       }

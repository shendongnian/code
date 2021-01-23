    using System;
    using System.Reflection;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                Type myType = (typeof(tblContacts));
                PropertyInfo[] myPropertyInfo = myType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                Console.WriteLine("The number of public properties is {0}.", myPropertyInfo.Length);
    
                // Display the public properties.
                DisplayPropertyInfo(myPropertyInfo);
    
                // Get the nonpublic properties.
                PropertyInfo[] myPropertyInfo1 = myType.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance);
                Console.WriteLine("The number of protected properties is {0}.", myPropertyInfo1.Length);
    
                // Display all the nonpublic properties.
                DisplayPropertyInfo(myPropertyInfo1);
            }
            public static void DisplayPropertyInfo(PropertyInfo[] myPropertyInfo)
            {
    
                // Display information for all properties. 
                for (int i = 0; i < myPropertyInfo.Length; i++)
                {
                    PropertyInfo myPropInfo = (PropertyInfo)myPropertyInfo[i];
                    Console.WriteLine("The property name is {0}.", myPropInfo.Name);
                    Console.WriteLine("The property type is {0}.", myPropInfo.PropertyType);
                }
            }
        }
    
        public class DisplayAttribute : Attribute
        {
            public bool IsDisplay;
            public string DisplayName;
    
            public DisplayAttribute()
            {
                IsDisplay = true;
                DisplayName = string.Empty;
            }
    
            public DisplayAttribute(bool isDisplay)
            {
                IsDisplay = isDisplay;
                DisplayName = string.Empty;
            }
    
            public DisplayAttribute(string displayName)
            {
                IsDisplay = true;
                DisplayName = displayName;
            }
    
            public DisplayAttribute(bool isDisplay, string displayName)
            {
                IsDisplay = isDisplay;
                DisplayName = displayName;
            }
        }
        public class tblContacts
        {
            [Display(false)]
            public int ContactId { get; set; }
    
            [Display(true, "Category Name")]
            public string CategoryName { get; set; }
    
            [Display("First Name")]
            public string FirstName { get; set; }
        }
    }

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication2
    {
        public partial class Form1 : Form
        {
            // Another simple way would be to create a class which has a constructor to hold the three strings
            public class PairedValues
            {
                public string value1 { get; set; }
                public string value2 { get; set; }
                public string value3 { get; set; }
    
                public PairedValues(string Value1, string Value2, string Value3)
                {
                    value1 = Value1;
                    value2 = Value2;
                    value3 = Value3;
                }
            }
    
            public Form1()
            {
                InitializeComponent();
    
                // Simply initialize a list of your new class
                List<PairedValues> pairedValues = new List<PairedValues>();
                pairedValues.Add(new PairedValues("string1", "string2", "string3"));
                pairedValues.Add(new PairedValues("string1", "string2", "string3"));
    
                // Accessing the values
                foreach (PairedValues pair in pairedValues)
                {
                    string value1 = pair.value1;
                    string value2 = pair.value2;
                    string value3 = pair.value3;
                }
            }
        }
    }

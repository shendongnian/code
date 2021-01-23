    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    
    namespace StackOverflow29203245
    {
        public partial class Form1 : Form
        {
            private readonly List<int> _numbers  = new List<int> {1, 2, 3, 4, 5};
            private readonly List<int> _asked = new List<int>();
    
            public Form1()
            {
                InitializeComponent();
            }
    
            /// <summary>
            /// Select random integer from the list of integers. If no numbers are left, throw an exception
            /// </summary>
            /// <returns>Random integer from the list</returns>
            private int RandomInteger()
            {
                if (_numbers.Count == 0)
                {
                    throw new Exception("All numbers have been selected");
                }
    
                var random = new Random();
                var index = random.Next(_numbers.Count);
                var selectedNumber = _numbers[index];
                _asked.Add(selectedNumber);
                _numbers.Remove(selectedNumber);
                return selectedNumber;
            }
    
    
            /// <summary>
            /// Show the message box. If all numbers are selected, show appropriate message
            /// </summary>
            private void ShowMessage(object sender, EventArgs e)
            {
                try
                {
                    MessageBox.Show(@"Number " + RandomInteger());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
    
    
            /// <summary>
            /// Reset numbers
            /// </summary>
            private void button6_Click(object sender, EventArgs e)
            {
                _numbers.AddRange(_asked);
                _asked.Clear();
            }
        }
    }

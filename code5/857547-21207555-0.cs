    static class Program
    {
        [STAThread]
        static void Main()
        {
            // Create example Form (normally you would create it with the VS Forms Designer)
            Form form = new Form();
            
            // Use a Panel to add the CheckBoxes during runtime
            Panel panel = new Panel();
            panel.Dock = DockStyle.Fill;
            panel.Parent = form;
 
            // Add a button to the form for creating the CheckBoxes during runtime
            Button button = new Button();
            button.Text = "Add a new CheckBox";
            button.Dock = DockStyle.Bottom;
            button.Parent = form;
 
            // On Button.Click we add a new CheckBox - we use a inline delegate here
            // Remark: Notice how the "outer" scope variables are captured.
            int iCount = 0;
            button.Click += delegate(object sender, EventArgs e)
            {
                iCount++;
                CreateCheckbox("cbDynamic" + iCount, "Dynamic" + iCount, panel, SampleCheckChangedHandler);
            }; 
 
            // Now let's create some Checkboxes in code 
            // I created a helper function to do the job.
            CreateCheckbox("cbActs", "Acts", panel, SampleCheckChangedHandler);
            CreateCheckbox("cbLaw", "Law", panel, SampleCheckChangedHandler);
            CreateCheckbox("cbHouses", "Houses", panel, SampleCheckChangedHandler);
            CreateCheckbox("cbCar", "Car", panel, SampleCheckChangedHandler);           
 
            Application.Run(form);
        }
 
        /// <summary>
        /// Helper function to create a CheckBox with common properties and adding it to the given parent control.
        /// </summary>
        /// <param name="Name"> Name for the new CheckBox </param>
        /// <param name="Text"> Text of the new CheckBox </param>
        /// <param name="ctrlParent"> Parent control for the new CheckBox (can be null if parent is set through other logic later) </param>
        /// <param name="handlerCheckChanged"> Handler for the CheckChanged event (can be null if no handler is needed) </param>
        /// <returns> The new Checkbox </returns>
        static CheckBox CreateCheckbox(string strName, string strText, Control ctrlParent, EventHandler handlerCheckChanged)
        {
            CheckBox cb = new CheckBox();
            cb.Name = strName;
            cb.Text = strText;
            cb.Dock = DockStyle.Top; // give a thought on how to do the dynamic layout,
            // maybe use a container control..
            cb.Parent = ctrlParent; // same as ctrlParent.Controls.Add(cb)
            // add some EventHandler (use this code as template if other handlers are commonly needded,
            // but add/set handlers/properties for specific CheckBoxes created with this function to the 
            // returned CheckBox object
            cb.CheckedChanged += handlerCheckChanged;
 
            return cb;
        }
 
        /// <summary>
        /// Sample eventhandler for the CheckChanged event
        /// </summary>
        static void SampleCheckChangedHandler(object objSender, EventArgs ea)
        {
            CheckBox cb = objSender as CheckBox; // get a reference to the checked/unchecked CheckBox
            // Do something just for demo
            if (cb.Checked)
                MessageBox.Show(cb.Text + " checked");
            else
                MessageBox.Show(cb.Text + " unchecked");
        }
    }
}

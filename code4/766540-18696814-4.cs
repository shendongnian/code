    private void ImportBothButtonclick(object sender, EventArgs e)
    {
        var selected = comboBox.SelectedItem;
        if (selected != null)
        {
            var val= (ComboBoxItem)selected;
            if (val != null)
            {
                // no Invoke needed, "button_click" handlers
                // are already on UI thread, so touching UI things is OK
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                // starting a new thread also does not need Invoke
                var thread = new Thread(DoAllFunctions);
                thread.Start(val); 
            }
        }
    }
    private void DoAllFunctions(object something)
    {
        DoFunction1(something);
        DoFunction2(something);
        // button1.Enabled = true; - cannot do it here because they are UI
        // button2.Enabled = true; - and DoAll is run from other thread.
        // button3.Enabled = true; - you must bounce that back to UI thread.
        LetTheUIKnowJobsAreFinished(); // <- performed here
    }
    private void LetTheUIKnowJobsAreFinished()
    {
        Invoke(new Action(()=>{
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
        });
    }

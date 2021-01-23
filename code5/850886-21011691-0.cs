     private int _loadCount;
    private void Form1_Load(object sender, System.EventArgs e)
    {
         _loadCount = 0;
         //Code to load values for controls...
    }
    private void CheckBox1_CheckedChanged(Object sender, EventArgs e) 
    {
       _loadCount++;
       if(_loadCount > 1)
      {
       //Do something here...
      }
      else
      {
       //Do nothing, return false, etc...
      }
    }

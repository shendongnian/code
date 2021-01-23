    public void put()
    {   
        string strDisplayMe = ModemKind.MainClass.inBuffer.MkRequest();
        if (strDisplayMe != "")
        {
            Console.Out.WriteLine("FOUND SOMETHING IN BUFFER: " + strDisplayMe);
            char[] DisplayMeArr = strDisplayMe.ToCharArray ();
            for (int i = 0; i <= DisplayMeArr.Length -1; ++i) 
            {
                AssignToTextBox(this.display, this.display.Text + DisplayMeArr [i]);
                Thread.Sleep (100);
            }
        AssignToTextBox(this.display, this.display.Text +  '\n');
        }
    }
    void AssignToTextBox(TextBox txtBox, string value)
    {
      if(txtBox.InvokeRequired)
      {
          txtBox.Invoke(new MethodInvoker(delegate { txtBox.text = value;      }));
      }
    }

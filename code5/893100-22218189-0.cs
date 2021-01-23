    myProcess.EnabledRaisingEvents = true
    myProcess.Exited += new EventHandler(myProcess_Exited);
    void myProcess_Exited(object sender, EventArgs e)
    {
        //process has exited, implement logic here
        listBox1.Items.RemoveAt(i); //though this will probably need an Invoke.
    }

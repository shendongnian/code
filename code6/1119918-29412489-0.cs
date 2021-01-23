    public delegate void EditCompletedEvent(List<string> strEditedValues);
    public event EditCompletedEvent EditCompleted;
    
    public void OKBtn_Click(object sender, EventArgs e)
    {
     if (this.EditCompleted!= null)
                    {
                        EditCompleted(listofEditedvalues);
                    }
    }
    
    //And in form1 assign event handler
    
    public void AddEntryBtn_Click(object sender, EventArgs e)
            {
                string x = label4.Text;
                using (var obj_Addentry = new AddEntry(x))
                {
                  obj_Addentry.EditCompleted += 
                       new Form2.EditCompletedEvent(obj_Addentry_EditCompleted)
                  obj_Addentry.ShowDialog();
                }
                this.Close();
            }
    
    obj_Addentry_EditCompleted(List<string> Editedvalues)
    {
    //Write down logic for assignment
    }

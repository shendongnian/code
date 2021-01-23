    public class MyForm : Form
    {
         private Dictionary<string, Label> assoc = new Dictionary<string, Label>();
         public MyForm()
         {
             // Key=Name of the TextBox, Value=Label associated with that textbox
             assoc.Add("textbox1", Label1);
             assoc.Add("textbox2", Label2);
             assoc.Add("textbox3", Label3);
         }
    }
    .....
    foreach (TextBox t in this.Controls.OfType<TextBox>())
    {
       if(t.Text.Length == 0)
       {
            assoc[t.Name].ForeColor = System.Drawing.Color.Red;
            err = true;
       }
       else
            assoc[t.Name].ForeColor = ??? system forecolor ???
    }

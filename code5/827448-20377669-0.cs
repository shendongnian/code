    public partial class MainForm : Form
    {
     var form2 = new ChildForm();
    public MainForm()
    {
        InitializeComponent();
    }
    private void showChildForms(object sender, EventArgs e)
    {
        createThread();
        createThread();
        createThread();
    }
    private  void createThread()
    {
        var t = new Thread(
               () =>
               {
                   this.Invoke(new Action(delegate
                   {
                       showForm();
                   }));
               }
               );
        t.IsBackground = true;
        t.Start();
    }
    private void showForm()
    {
        
         Form res = new Form();
            foreach (Form form in Application.OpenForms)
            {
                if (form.Text == "Form2")//or form.Name u can use how you are assigning in form2 
                {
                    res = form;
                    break;
                }
            }
            res.Close();
        
             // Do what ever.The above part will close the previous instances of the Forms.
    }
    }
